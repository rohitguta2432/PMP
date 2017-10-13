
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
	public class TaskStatusLogDTO
    {
		public System.Int32 TaskStatusLogID { get; set; }
		public System.Int32? CurrentStatusID { get; set; }
		public System.Int32? TaskAssignmentID { get; set; }
		public System.DateTime? ChangedDate { get; set; }
		public System.DateTime? DueDate { get; set; }
		public System.String Reason { get; set; }
		public System.DateTime? LastUpdated { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string CurrentStatusMaster_CurrentStatusDesc { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string TaskAssignment_TaskDescription { get; set; }

        public static System.Linq.Expressions.Expression<Func< TaskStatusLog,  TaskStatusLogDTO>> SELECT =
            x => new  TaskStatusLogDTO
            {
                TaskStatusLogID = x.TaskStatusLogID,
                CurrentStatusID = x.CurrentStatusID,
                TaskAssignmentID = x.TaskAssignmentID,
                ChangedDate = x.ChangedDate,
                DueDate = x.DueDate,
                Reason = x.Reason,
                LastUpdated = x.LastUpdated,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                CurrentStatusMaster_CurrentStatusDesc = x.CurrentStatusMaster.CurrentStatusDesc,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                TaskAssignment_TaskDescription = x.TaskAssignment.TaskDescription,
            };

	}
}