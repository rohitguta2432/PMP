
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
	public class ExpenseDetailDTO
    {
		public System.Int32 ExpenseID { get; set; }
		public System.Int32? PhaseID { get; set; }
		public System.Int32? ResearchTypeID { get; set; }
		public System.Int32? MethodID { get; set; }
		public System.String TargetAud { get; set; }
		public System.Int32? Units { get; set; }
		public System.Decimal? FeePerUnit { get; set; }
		public System.Decimal? TotalFee { get; set; }
		public System.Int32? CurrencyID { get; set; }
		public System.Int32? TimingDays { get; set; }
		public System.Decimal? EstMargin { get; set; }
		public System.Int32? ProjectID { get; set; }
		public System.Decimal? TotalExpense { get; set; }
		public System.Decimal? EmployeeContrib { get; set; }
		public System.Decimal? GrandTotal { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string CurrencyDetail_CurrencyDesc { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string MethodologyMaster_MethodDesc { get; set; }
		public string PhaseMaster_PhaseDesc { get; set; }
		public string ProjectDetail_ProjectDesc { get; set; }
		public string ResearchTypeMaster_ResearchDesc { get; set; }
		public int PhaseExpenseDetails_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< ExpenseDetail,  ExpenseDetailDTO>> SELECT =
            x => new  ExpenseDetailDTO
            {
                ExpenseID = x.ExpenseID,
                PhaseID = x.PhaseID,
                ResearchTypeID = x.ResearchTypeID,
                MethodID = x.MethodID,
                TargetAud = x.TargetAud,
                Units = x.Units,
                FeePerUnit = x.FeePerUnit,
                TotalFee = x.TotalFee,
                CurrencyID = x.CurrencyID,
                TimingDays = x.TimingDays,
                EstMargin = x.EstMargin,
                ProjectID = x.ProjectID,
                TotalExpense = x.TotalExpense,
                EmployeeContrib = x.EmployeeContrib,
                GrandTotal = x.GrandTotal,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                CurrencyDetail_CurrencyDesc = x.CurrencyDetail.CurrencyDesc,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                MethodologyMaster_MethodDesc = x.MethodologyMaster.MethodDesc,
                PhaseMaster_PhaseDesc = x.PhaseMaster.PhaseDesc,
                ProjectDetail_ProjectDesc = x.ProjectDetail.ProjectDesc,
                ResearchTypeMaster_ResearchDesc = x.ResearchTypeMaster.ResearchDesc,
                PhaseExpenseDetails_Count = x.PhaseExpenseDetails.Count(),
            };

	}
}