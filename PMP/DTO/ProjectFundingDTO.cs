
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
	public class ProjectFundingDTO
    {
		public System.Int32 FundID { get; set; }
		public System.Decimal? FundsReleased { get; set; }
		public System.Decimal? FundsRecieved { get; set; }
		public System.Decimal? FundsInvested { get; set; }
		public System.DateTime? ReleasedOn { get; set; }
		public System.Int32? ReleasedTo { get; set; }
		public System.Int32? ReleasedBy { get; set; }
		public System.Int32? ProjectAccountID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string ProjectAccountsDetail_PONumber { get; set; }

        public static System.Linq.Expressions.Expression<Func< ProjectFunding,  ProjectFundingDTO>> SELECT =
            x => new  ProjectFundingDTO
            {
                FundID = x.FundID,
                FundsReleased = x.FundsReleased,
                FundsRecieved = x.FundsRecieved,
                FundsInvested = x.FundsInvested,
                ReleasedOn = x.ReleasedOn,
                ReleasedTo = x.ReleasedTo,
                ReleasedBy = x.ReleasedBy,
                ProjectAccountID = x.ProjectAccountID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ProjectAccountsDetail_PONumber = x.ProjectAccountsDetail.PONumber,
            };

	}
}