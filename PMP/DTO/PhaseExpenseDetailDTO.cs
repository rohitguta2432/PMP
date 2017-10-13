
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
	public class PhaseExpenseDetailDTO
    {
		public System.Int32 PhaseExpenseID { get; set; }
		public System.Int32? ExpenseHeadID { get; set; }
		public System.Int32? ExpenseTypeID { get; set; }
		public System.Int32? VendorID { get; set; }
		public System.String Remarks { get; set; }
		public System.Int32? ExpenseID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public int ActualExpenseDetails_Count { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int EstimatedExpenseDetails_Count { get; set; }
		public string ExpenseDetail_TargetAud { get; set; }
		public string ExpenseHeadMaster_ExpenseHeadDesc { get; set; }
		public string ExpenseTypeMaster_ExpenseTypeDesc { get; set; }
		public string VendorMaster_VendorDesc { get; set; }

        public static System.Linq.Expressions.Expression<Func< PhaseExpenseDetail,  PhaseExpenseDetailDTO>> SELECT =
            x => new  PhaseExpenseDetailDTO
            {
                PhaseExpenseID = x.PhaseExpenseID,
                ExpenseHeadID = x.ExpenseHeadID,
                ExpenseTypeID = x.ExpenseTypeID,
                VendorID = x.VendorID,
                Remarks = x.Remarks,
                ExpenseID = x.ExpenseID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ActualExpenseDetails_Count = x.ActualExpenseDetails.Count(),
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                EstimatedExpenseDetails_Count = x.EstimatedExpenseDetails.Count(),
                ExpenseDetail_TargetAud = x.ExpenseDetail.TargetAud,
                ExpenseHeadMaster_ExpenseHeadDesc = x.ExpenseHeadMaster.ExpenseHeadDesc,
                ExpenseTypeMaster_ExpenseTypeDesc = x.ExpenseTypeMaster.ExpenseTypeDesc,
                VendorMaster_VendorDesc = x.VendorMaster.VendorDesc,
            };

	}
}