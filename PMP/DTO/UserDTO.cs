
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PMP
{
    public class UserDTO
    {
        public System.Int32 UserID { get; set; }
        public System.String UserName { get; set; }
        public System.String Password { get; set; }
        public System.Int32? DesignationID { get; set; }
        public System.Int32? CreatedBy { get; set; }
        public System.DateTime? CreatedDate { get; set; }
        public System.Int32? ModifiedBy { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public string EmployeeMaster_EmployeeCode { get; set; }
        public string Designation_DesignationDesc { get; set; }


        public static System.Linq.Expressions.Expression<Func<User, UserDTO>> SELECT =
            x => new UserDTO
            {
                UserID = x.UserID,
                UserName = x.UserName,
                Password = x.Password,
                DesignationID = x.DesignationID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,                
                Designation_DesignationDesc = x.Designation.DesignationDesc,
            };        
    }

    public class LoginModel
    {
        public System.String UserName { get; set; }
        public System.String Password { get; set; }
    }
    public class RegisterModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    }
    public class ForgotPasswordModel
    {
        public string Email { get; set; }
    }
    public class ResetPasswordModel
    {        
       public string UserID { get; set; }

       public string Password { get; set; }

       public string ConfirmPassword { get; set; }

       public string Code { get; set; }
    }

}