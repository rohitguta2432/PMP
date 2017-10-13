
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
	public class TaskMasterDTO
    {
		public System.Int32 TaskID { get; set; }
		public System.String TaskName { get; set; }
		public System.Boolean? IsActive { get; set; }
		public System.Int32? Stage { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public int TaskAssignments_Count { get; set; }
        public string StageMaster_StageDesc { get; set; }

        public static System.Linq.Expressions.Expression<Func< TaskMaster,  TaskMasterDTO>> SELECT =
            x => new  TaskMasterDTO
            {
                TaskID = x.TaskID,
                TaskName = x.TaskName,
                IsActive = x.IsActive,
                Stage = x.Stage,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                TaskAssignments_Count = x.TaskAssignments.Count(),
                StageMaster_StageDesc=x.StageMaster.StageDesc,
            };

	}
}