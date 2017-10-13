
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
	public class DesignationDTO
    {
		public System.Int32 DesignationID { get; set; }
		public System.String DesignationDesc { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public int AuthMappings_Count { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int EmployeeMasters_Count { get; set; }
        public int Users_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< Designation,  DesignationDTO>> SELECT =
            x => new  DesignationDTO
            {
                DesignationID = x.DesignationID,
                DesignationDesc = x.DesignationDesc,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                AuthMappings_Count = x.AuthMappings.Count(),
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                EmployeeMasters_Count = x.EmployeeMasters.Count(),
                Users_Count=x.Users.Count(),
            };

	}
}