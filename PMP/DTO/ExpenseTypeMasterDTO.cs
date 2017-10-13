
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
	public class ExpenseTypeMasterDTO
    {
		public System.Int32 ExpenseTypeID { get; set; }
		public System.String ExpenseTypeDesc { get; set; }
		public System.String ExpenseTypeCode { get; set; }
		public System.Int32? ExpenseHeadID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string ExpenseHeadMaster_ExpenseHeadDesc { get; set; }
		public int PhaseExpenseDetails_Count { get; set; }
		public int VendorMasters_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< ExpenseTypeMaster,  ExpenseTypeMasterDTO>> SELECT =
            x => new  ExpenseTypeMasterDTO
            {
                ExpenseTypeID = x.ExpenseTypeID,
                ExpenseTypeDesc = x.ExpenseTypeDesc,
                ExpenseTypeCode = x.ExpenseTypeCode,
                ExpenseHeadID = x.ExpenseHeadID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ExpenseHeadMaster_ExpenseHeadDesc = x.ExpenseHeadMaster.ExpenseHeadDesc,
                PhaseExpenseDetails_Count = x.PhaseExpenseDetails.Count(),
                VendorMasters_Count = x.VendorMasters.Count(),
            };

	}
}