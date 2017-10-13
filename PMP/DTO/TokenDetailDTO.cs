
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PMP
{
	public class TokenDetailDTO
    {
		public System.Int32 TokenID { get; set; }
		public System.String TokenKey { get; set; }
		public System.Int32? ClientID { get; set; }
		public System.Int32? ContactPersonID { get; set; }
		public System.DateTime? ContactDate { get; set; }
		public System.Int32? ChannelID { get; set; }
		public System.Int32? SourceID { get; set; }
		public System.Int32? InquiryTypeID { get; set; }
		public System.String Objective { get; set; }
		public System.String TargetAudience { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.Int32? Manager { get; set; }
		public System.Int32? CurrentStatusID { get; set; }
		public System.String ReferenceName { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string ChannelMaster_ChannelName { get; set; }
		public string ClientMaster_ClientName { get; set; }
		public string ContactPersonMaster_ContactPersonName { get; set; }
		public string CurrentStatusMaster_CurrentStatusDesc { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string EmployeeMaster2_EmployeeCode { get; set; }
		public int InitialProjects_Count { get; set; }
		public string InquiryTypeMaster_InquiryTypeDesc { get; set; }
		public int ProjectClosureDetails_Count { get; set; }
		public int ProjectDetails_Count { get; set; }
		public string SourceMaster_SourceDesc { get; set; }
		public int TaskAssignments_Count { get; set; }
        public string ContactDateFormat { get; set; }
        public string EmployeeMaster1_FirstName { get; set; }
        public string ModifiedDateFormat { get; set; }


        public static System.Linq.Expressions.Expression<Func<TokenDetail, TokenDetailDTO>> SELECT =
            x => new TokenDetailDTO
            {
                TokenID = x.TokenID,
                TokenKey = x.TokenKey,
                ClientID = x.ClientID,
                ContactPersonID = x.ContactPersonID,
                ContactDate = x.ContactDate,
                ChannelID = x.ChannelID,
                SourceID = x.SourceID,
                InquiryTypeID = x.InquiryTypeID,
                Objective = x.Objective,
                TargetAudience = x.TargetAudience,
                CreatedBy = x.CreatedBy,
                Manager = x.Manager,
                CurrentStatusID = x.CurrentStatusID,
                ReferenceName = x.ReferenceName,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ChannelMaster_ChannelName = x.ChannelMaster.ChannelName,
                ClientMaster_ClientName = x.ClientMaster.ClientName,
                ContactPersonMaster_ContactPersonName = x.ContactPersonMaster.ContactPersonName,
                CurrentStatusMaster_CurrentStatusDesc = x.CurrentStatusMaster.CurrentStatusDesc,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                EmployeeMaster2_EmployeeCode = x.EmployeeMaster2.EmployeeCode,
                InitialProjects_Count = x.InitialProjects.Count(),
                InquiryTypeMaster_InquiryTypeDesc = x.InquiryTypeMaster.InquiryTypeDesc,
                ProjectClosureDetails_Count = x.ProjectClosureDetails.Count(),
                ProjectDetails_Count = x.ProjectDetails.Count(),
                SourceMaster_SourceDesc = x.SourceMaster.SourceDesc,
                TaskAssignments_Count = x.TaskAssignments.Count(),
                ContactDateFormat = (x.ContactDate != null ?
                (SqlFunctions.DateName("dd", x.ContactDate).Trim().Length == 1 ? "0" + SqlFunctions.DateName("dd", x.ContactDate).Trim() : SqlFunctions.DateName("dd", x.ContactDate).Trim()) + "/" +
                (SqlFunctions.StringConvert((double)x.ContactDate.Value.Month).TrimStart().Length == 1 ? "0" + SqlFunctions.StringConvert((double)x.ContactDate.Value.Month).TrimStart() : SqlFunctions.StringConvert((double)x.ContactDate.Value.Month).TrimStart()) + "/" +
                SqlFunctions.DateName("yyyy", x.ContactDate)
                : ""),
                EmployeeMaster1_FirstName = x.EmployeeMaster1.FirstName,
                ModifiedDateFormat = (x.ModifiedDate != null ?
                (SqlFunctions.DateName("dd", x.ModifiedDate).Trim().Length == 1 ? "0" + SqlFunctions.DateName("dd", x.ModifiedDate).Trim() : SqlFunctions.DateName("dd", x.ModifiedDate).Trim()) + "/" +
                (SqlFunctions.StringConvert((double)x.ModifiedDate.Value.Month).TrimStart().Length == 1 ? "0" + SqlFunctions.StringConvert((double)x.ModifiedDate.Value.Month).TrimStart() : SqlFunctions.StringConvert((double)x.ModifiedDate.Value.Month).TrimStart()) + "/" +
                SqlFunctions.DateName("yyyy", x.ContactDate)
                : ""),

            };
       

	}
}