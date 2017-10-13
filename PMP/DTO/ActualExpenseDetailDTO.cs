
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
	public class ActualExpenseDetailDTO
    {
		public System.Int32 ActualExpenseID { get; set; }
		public System.Int32? Units { get; set; }
		public System.Decimal? UnitRate { get; set; }
		public System.Decimal? Cost { get; set; }
		public System.Int32? PhaseExpenseID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string PhaseExpenseDetail_Remarks { get; set; }

        public static System.Linq.Expressions.Expression<Func< ActualExpenseDetail,  ActualExpenseDetailDTO>> SELECT =
            x => new  ActualExpenseDetailDTO
            {
                ActualExpenseID = x.ActualExpenseID,
                Units = x.Units,
                UnitRate = x.UnitRate,
                Cost = x.Cost,
                PhaseExpenseID = x.PhaseExpenseID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                PhaseExpenseDetail_Remarks = x.PhaseExpenseDetail.Remarks,
            };

	}
}