
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
	public class CurrencyDetailDTO
    {
		public System.Int32 CurrencyID { get; set; }
		public System.String CurrencyDesc { get; set; }
		public System.String CurrencyCode { get; set; }
		public System.Decimal? ConvertFactor { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int ExpenseDetails_Count { get; set; }
		public int ProjectAccountsDetails_Count { get; set; }
		public int CurrencySettings_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< CurrencyDetail,  CurrencyDetailDTO>> SELECT =
            x => new  CurrencyDetailDTO
            {
                CurrencyID = x.CurrencyID,
                CurrencyDesc = x.CurrencyDesc,
                CurrencyCode = x.CurrencyCode,
                ConvertFactor = x.ConvertFactor,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ExpenseDetails_Count = x.ExpenseDetails.Count(),
                ProjectAccountsDetails_Count = x.ProjectAccountsDetails.Count(),
                CurrencySettings_Count = x.CurrencySettings.Count(),
            };

	}
}