
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
	public class AuthMappingDTO
    {
		public System.Int32 AuthID { get; set; }
		public System.Int32? DesignationID { get; set; }
		public System.Int32? PageID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string Designation_DesignationDesc { get; set; }
		public string PageRulesMaster_PageDesc { get; set; }
        public string PageRulesMaster_PageState { get; set; }
        public System.Int32? PageRulesMaster_ParentPage { get; set; }

        public static System.Linq.Expressions.Expression<Func< AuthMapping,  AuthMappingDTO>> SELECT =
            x => new  AuthMappingDTO
            {
                AuthID = x.AuthID,
                DesignationID = x.DesignationID,
                PageID = x.PageID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                Designation_DesignationDesc = x.Designation.DesignationDesc,
                PageRulesMaster_PageDesc = x.PageRulesMaster.PageDesc,
                PageRulesMaster_PageState=x.PageRulesMaster.PageState,
                PageRulesMaster_ParentPage=x.PageRulesMaster.ParentPage,
            };

	}
}