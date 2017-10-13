
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
	public class PageRulesMasterDTO
    {
		public System.Int32 PageID { get; set; }
		public System.String PageDesc { get; set; }
        public string PageState { get; set; }
        public System.Int32? ParentPage { get; set; }
        public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public int AuthMappings_Count { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }

        public static System.Linq.Expressions.Expression<Func< PageRulesMaster,  PageRulesMasterDTO>> SELECT =
            x => new  PageRulesMasterDTO
            {
                PageID = x.PageID,
                PageDesc = x.PageDesc,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                AuthMappings_Count = x.AuthMappings.Count(),
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
            };

	}
}