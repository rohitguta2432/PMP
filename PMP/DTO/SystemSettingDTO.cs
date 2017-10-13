
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
	public class SystemSettingDTO
    {
		public System.Int32 CurrencySettingID { get; set; }
		public System.Int32? CurrencyID { get; set; }
		public System.Int32? BaseCurrencyID { get; set; }
		public System.Decimal? CurrencyRate { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }

        public static System.Linq.Expressions.Expression<Func< SystemSetting,  SystemSettingDTO>> SELECT =
            x => new  SystemSettingDTO
            {
                CurrencySettingID = x.CurrencySettingID,
                CurrencyID = x.CurrencyID,
                BaseCurrencyID = x.BaseCurrencyID,
                CurrencyRate = x.CurrencyRate,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
            };

	}
}