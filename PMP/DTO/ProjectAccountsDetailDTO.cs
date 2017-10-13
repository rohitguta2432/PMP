
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
	public class ProjectAccountsDetailDTO
    {
		public System.Int32 ProjectAccountingID { get; set; }
		public System.Int32? ProjectID { get; set; }
		public System.String PONumber { get; set; }
		public System.Decimal? ProjectFees { get; set; }
		public System.Int32? CurrencyID { get; set; }
		public System.Decimal? EstCost { get; set; }
		public System.Decimal? EstProfit { get; set; }
		public System.Decimal? ActCost { get; set; }
		public System.Decimal? ActProfit { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string CurrencyDetail_CurrencyDesc { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string ProjectDetail_ProjectDesc { get; set; }
		public int ProjectFundings_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< ProjectAccountsDetail,  ProjectAccountsDetailDTO>> SELECT =
            x => new  ProjectAccountsDetailDTO
            {
                ProjectAccountingID = x.ProjectAccountingID,
                ProjectID = x.ProjectID,
                PONumber = x.PONumber,
                ProjectFees = x.ProjectFees,
                CurrencyID = x.CurrencyID,
                EstCost = x.EstCost,
                EstProfit = x.EstProfit,
                ActCost = x.ActCost,
                ActProfit = x.ActProfit,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                CurrencyDetail_CurrencyDesc = x.CurrencyDetail.CurrencyDesc,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ProjectDetail_ProjectDesc = x.ProjectDetail.ProjectDesc,
                ProjectFundings_Count = x.ProjectFundings.Count(),
            };

	}
}