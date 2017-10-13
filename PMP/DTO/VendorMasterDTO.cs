
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
	public class VendorMasterDTO
    {
		public System.Int32 VendorID { get; set; }
		public System.String VendorDesc { get; set; }
		public System.Int32? ExpenseTypeID { get; set; }
		public System.Boolean? IsActive { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string ExpenseTypeMaster_ExpenseTypeDesc { get; set; }
		public int PhaseExpenseDetails_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< VendorMaster,  VendorMasterDTO>> SELECT =
            x => new  VendorMasterDTO
            {
                VendorID = x.VendorID,
                VendorDesc = x.VendorDesc,
                ExpenseTypeID = x.ExpenseTypeID,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ExpenseTypeMaster_ExpenseTypeDesc = x.ExpenseTypeMaster.ExpenseTypeDesc,
                PhaseExpenseDetails_Count = x.PhaseExpenseDetails.Count(),
            };

	}
}