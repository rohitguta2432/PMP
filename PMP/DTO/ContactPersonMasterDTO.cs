
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
	public class ContactPersonMasterDTO
    {
		public System.Int32 ContactPersonID { get; set; }
		public System.String ContactPersonName { get; set; }
		public System.String ContactPersonCode { get; set; }
		public System.String MobileNumber { get; set; }
		public System.String EmailID { get; set; }
		public System.Boolean? IsActive { get; set; }
		public System.Int32? ClientID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string ClientMaster_ClientName { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int TokenDetails_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< ContactPersonMaster,  ContactPersonMasterDTO>> SELECT =
            x => new  ContactPersonMasterDTO
            {
                ContactPersonID = x.ContactPersonID,
                ContactPersonName = x.ContactPersonName,
                ContactPersonCode = x.ContactPersonCode,
                MobileNumber = x.MobileNumber,
                EmailID = x.EmailID,
                IsActive = x.IsActive,
                ClientID = x.ClientID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ClientMaster_ClientName = x.ClientMaster.ClientName,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                TokenDetails_Count = x.TokenDetails.Count(),
            };

	}
}