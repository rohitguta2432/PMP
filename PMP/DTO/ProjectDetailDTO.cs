
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
	public class ProjectDetailDTO
    {
		public System.Int32 ProjectID { get; set; }
		public System.Int32? TokenID { get; set; }
		public System.String ProjectDesc { get; set; }
		public System.Int32? IndustryID { get; set; }
		public System.Int32? ClientID { get; set; }
		public System.Int32? ProductCatID { get; set; }
		public System.Int32? BrandID { get; set; }
		public System.DateTime? ProposalDate { get; set; }
		public System.DateTime? StartDate { get; set; }
		public System.DateTime? EndDate { get; set; }
		public System.Int32? ManagerID { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string BrandMaster_BrandDesc { get; set; }
		public string ClientMaster_ClientName { get; set; }
		public int DNAAmbassadorDetails_Count { get; set; }
		public int DNAManagerDetails_Count { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string EmployeeMaster2_EmployeeCode { get; set; }
		public int ExpenseDetails_Count { get; set; }
		public string IndustryMaster_IndustryDesc { get; set; }
		public string ProductCatMaster_ProductDesc { get; set; }
		public int ProjectAccountsDetails_Count { get; set; }
		public string TokenDetail_TokenKey { get; set; }

        public static System.Linq.Expressions.Expression<Func< ProjectDetail,  ProjectDetailDTO>> SELECT =
            x => new  ProjectDetailDTO
            {
                ProjectID = x.ProjectID,
                TokenID = x.TokenID,
                ProjectDesc = x.ProjectDesc,
                IndustryID = x.IndustryID,
                ClientID = x.ClientID,
                ProductCatID = x.ProductCatID,
                BrandID = x.BrandID,
                ProposalDate = x.ProposalDate,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                ManagerID = x.ManagerID,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                BrandMaster_BrandDesc = x.BrandMaster.BrandDesc,
                ClientMaster_ClientName = x.ClientMaster.ClientName,
                DNAAmbassadorDetails_Count = x.DNAAmbassadorDetails.Count(),
                DNAManagerDetails_Count = x.DNAManagerDetails.Count(),
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                EmployeeMaster2_EmployeeCode = x.EmployeeMaster2.EmployeeCode,
                ExpenseDetails_Count = x.ExpenseDetails.Count(),
                IndustryMaster_IndustryDesc = x.IndustryMaster.IndustryDesc,
                ProductCatMaster_ProductDesc = x.ProductCatMaster.ProductDesc,
                ProjectAccountsDetails_Count = x.ProjectAccountsDetails.Count(),
                TokenDetail_TokenKey = x.TokenDetail.TokenKey,
            };

	}
}