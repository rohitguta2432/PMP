
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
	public class ProjectClosureDetailDTO
    {
		public System.Int32 ProjectClosureID { get; set; }
		public System.Int32? TokenID { get; set; }
		public System.Int32? DocumentID { get; set; }
		public System.Int32? CRPStatus { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string CRPStatu_CRPStatusDesc { get; set; }
		public string DocumentDetail_DocumentDesc { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string TokenDetail_TokenKey { get; set; }

        public static System.Linq.Expressions.Expression<Func< ProjectClosureDetail,  ProjectClosureDetailDTO>> SELECT =
            x => new  ProjectClosureDetailDTO
            {
                ProjectClosureID = x.ProjectClosureID,
                TokenID = x.TokenID,
                DocumentID = x.DocumentID,
                CRPStatus = x.CRPStatus,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                CRPStatu_CRPStatusDesc = x.CRPStatu.CRPStatusDesc,
                DocumentDetail_DocumentDesc = x.DocumentDetail.DocumentName,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                TokenDetail_TokenKey = x.TokenDetail.TokenKey,
            };

	}
}