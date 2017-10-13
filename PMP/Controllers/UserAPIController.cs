using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PMP.Providers;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace PMP
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private PMP.PMPEntities db = new PMP.PMPEntities();
        private AuthRepository _repo = null;

        public UserController() {
            _repo = new AuthRepository();
        }

        public IQueryable<UserDTO> GetUsers(int pageSize = 10
                        , System.Int32? DesignationID = null
                        , System.Int32? CreatedBy = null
                        , System.Int32? ModifiedBy = null
            )
        {
            var model = db.Users.AsQueryable();
            if (DesignationID != null)
            {
                model = model.Where(m => m.DesignationID == DesignationID.Value);
            }

            if (CreatedBy != null)
            {
                model = model.Where(m => m.CreatedBy == CreatedBy.Value);
            }
            if (ModifiedBy != null)
            {
                model = model.Where(m => m.ModifiedBy == ModifiedBy.Value);
            }

            return model.Select(UserDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(UserDTO))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var model = await db.Users.Select(UserDTO.SELECT).FirstOrDefaultAsync(x => x.UserID == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [ResponseType(typeof(UserDTO))]
        public async Task<IHttpActionResult> GetUser(string UserName, string Password)
        {
            var modeldata = await db.Users.Select(UserDTO.SELECT).FirstOrDefaultAsync(x => x.UserName == UserName && x.Password == Password);
            if (modeldata == null)
            {
                return NotFound();
            }
           // HttpContext.Current.Session["UserID"] = modeldata.UserID;
            return Ok(modeldata);
        }

        public async Task<IHttpActionResult> PutUser(int id, User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.UserID)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(UserDTO))]
        public async Task<IHttpActionResult> PostUser(User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Users.Select(UserDTO.SELECT).FirstOrDefaultAsync(x => x.UserID == model.UserID);
            return CreatedAtRoute("DefaultApi", new { id = model.UserID }, model);
        }

        [ResponseType(typeof(UserDTO))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User model = await db.Users.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Users.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.Users.Select(UserDTO.SELECT).FirstOrDefaultAsync(x => x.UserID == model.UserID);
            return Ok(ret);
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok("You are successfully registered");
        }

        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var callBackUrl = Request.RequestUri.GetLeftPart(System.UriPartial.Authority);
            var user = await _repo.FindByNameAsync(model.Email, callBackUrl);
            if (user == null)
            {
                return BadRequest("User Name Not Exits.");
            }
            return Ok("Please check your email to reset your password.");
        }

        [AllowAnonymous]
        [Route("ResetPassword")]
        public async Task<IHttpActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _repo.ResetPasswordAsync(model.UserID, model.Code, model.Password);
            if(result==null)
            {
                return BadRequest("Token is invalid");
            }
            return Ok("Password reset successfully.");
        }

        [HttpGet]        
        [Route("FindUser/{UserID}")]
        public async Task<IHttpActionResult> FindUserByID(string UserID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _repo.FindById(UserID);
            if (result == null)
            {
                return BadRequest("User does not Exist");
            }
            return Ok(result);
        }

        [HttpGet]
        [ResponseType(typeof(EmployeeMaster))]
        [Route("GetUserName/{UserName}")]
        public async Task<IHttpActionResult> GetUserName(string UserName)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDetailModel = await _repo.FindByName(UserName);
            var empModel = (from emp in db.EmployeeMasters
                           where emp.EmployeeID == userDetailModel.EmployeeID
                           select emp).FirstOrDefaultAsync();
            //var empModel = await db.EmployeeMasters.Select(EmployeeMasterDTO.SELECT).FirstOrDefaultAsync(x => x.EmployeeID == userDetailModel.EmployeeID);
            if (empModel == null)
            {
                return NotFound();
            }
            return Ok(empModel);
           
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }


    }
}