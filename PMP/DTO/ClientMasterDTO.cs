
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
	public class ClientMasterDTO
    {
		public System.Int32 ClientID { get; set; }
		public System.String ClientName { get; set; }
		public System.String ClientCode { get; set; }
		public System.String Address { get; set; }
		public System.String PhoneNumber { get; set; }
		public System.String Fax { get; set; }
		public System.String EmailID { get; set; }
		public System.Int32? StatusID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int ContactPersonMasters_Count { get; set; }
		public int ProjectDetails_Count { get; set; }
		public int TokenDetails_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< ClientMaster,  ClientMasterDTO>> SELECT =
            x => new  ClientMasterDTO
            {
                ClientID = x.ClientID,
                ClientName = x.ClientName,
                ClientCode = x.ClientCode,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Fax = x.Fax,
                EmailID = x.EmailID,
                StatusID = x.StatusID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ContactPersonMasters_Count = x.ContactPersonMasters.Count(),
                ProjectDetails_Count = x.ProjectDetails.Count(),
                TokenDetails_Count = x.TokenDetails.Count(),
            };

	}
}