using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace PMP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class PMPUser : IdentityUser
    {
        public string Hometown { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> UserID { get; set; }       

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<PMPUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<PMPUser>
    {
        //Preeti//
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        //public ApplicationDbContext()
        //    : base("PMPEntities", throwIfV1Schema: false)
        //{
        //}
        //Preeti//
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}