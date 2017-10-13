
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
	public class DocumentDetailDTO
    {
		public System.Int32 DocumentID { get; set; }
		public System.String DocumentName { get; set; }
        public byte[] Data { get; set; }
        public System.String DocumentExtension { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int InitialProjects_Count { get; set; }
		public int ProjectClosureDetails_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< DocumentDetail,  DocumentDetailDTO>> SELECT =
            x => new  DocumentDetailDTO
            {
                DocumentID = x.DocumentID,
                Data=x.Data,
                DocumentName = x.DocumentName,
                DocumentExtension = x.DocumentExtension,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                InitialProjects_Count = x.InitialProjects.Count(),
                ProjectClosureDetails_Count = x.ProjectClosureDetails.Count(),
            };

	}
}