
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
	public class ExpenseHeadMasterDTO
    {
		public System.Int32 ExpenseHeadID { get; set; }
		public System.String ExpenseHeadDesc { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int ExpenseTypeMasters_Count { get; set; }
		public int PhaseExpenseDetails_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< ExpenseHeadMaster,  ExpenseHeadMasterDTO>> SELECT =
            x => new  ExpenseHeadMasterDTO
            {
                ExpenseHeadID = x.ExpenseHeadID,
                ExpenseHeadDesc = x.ExpenseHeadDesc,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ExpenseTypeMasters_Count = x.ExpenseTypeMasters.Count(),
                PhaseExpenseDetails_Count = x.PhaseExpenseDetails.Count(),
            };

	}
}