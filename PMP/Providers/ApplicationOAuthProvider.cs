using System;
using PMP.Models;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Web;

namespace PMP.Providers
{

    public class AuthRepository : IDisposable
    {
        private ApplicationDbContext _ctx;

        private UserManager<PMPUser> _userManager;

        public AuthRepository()
        {
            _ctx = ApplicationDbContext.Create();
            _userManager = new UserManager<PMPUser>(new UserStore<PMPUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel userModel)
        {
            PMPUser user = new PMPUser
            {
                UserName = userModel.UserName,
                Email = userModel.EmailID
            };

            user.DesignationID = userModel.DesignationID;
            user.EmployeeID = userModel.EmployeeID;


            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<PMPUser> FindUser(string userName, string password)
        {
            PMPUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<PMPUser> FindByNameAsync(string userName, string callBackUrlLeftPart)
        {
            PMPUser user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                await _userManager.IsEmailConfirmedAsync(user.Id);
                var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ASP.NET IDENTITY");
                _userManager.UserTokenProvider = new Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider<PMPUser>(provider.Create("ASP.NET Identity"));
                var code = await _userManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = callBackUrlLeftPart + "/#!/Reset/" + user.Id + "?Code=" + code;
                _userManager.EmailService = EmailService.Create(user.Email);
                await _userManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking here:<a href=\"" + callbackUrl + "\">link</a>");
            }
            return user;
        }
        public async Task<PMPUser> ResetPasswordAsync(string userID, string code, string password)
        {
            PMPUser user = await _userManager.FindByIdAsync(userID);
            if (user!=null)
            {
                var provider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ASP.NET IDENTITY");
                _userManager.UserTokenProvider = new Microsoft.AspNet.Identity.Owin.DataProtectorTokenProvider<PMPUser>(provider.Create("ASP.NET Identity"));
                //FIXME Implement Full Proof Solution
                String correctedCode = code.Replace(" ", "+");
                var result = await _userManager.ResetPasswordAsync(userID, correctedCode, password);
                if(!result.Succeeded)
                {
                    user = null;
                }               
            }

            return user;
        }
        public async Task<PMPUser> FindById(string userID)
        {
            PMPUser user = await _userManager.FindByIdAsync(userID);           
            return user;
        }
        public async Task<PMPUser> FindByName(string userName)
        {
            PMPUser user = await _userManager.FindByNameAsync(userName);         
            return user;
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }

    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
                else if (context.ClientId == "web")
                {
                    var expectedUri = new Uri(context.Request.Uri, "/");
                    context.Validated(expectedUri.AbsoluteUri);
                }
            }

            return Task.FromResult<object>(null);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuthRepository _repo = new AuthRepository())
            {
                PMPUser user = await _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }

    }
}