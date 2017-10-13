
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
	public class TaskAssignmentDTO
    {
		public System.Int32 TaskAssignmentID { get; set; }
		public System.Int32? TokenID { get; set; }
		public System.Int32? TaskID { get; set; }
		public System.String TaskDescription { get; set; }
		public System.Int32? TaskPriorityID { get; set; }
		public System.DateTime? DueDate { get; set; }
		public System.Int32? LinkTask { get; set; }
		public System.DateTime? AssignedOn { get; set; }
		public System.Int32? AssignedByID { get; set; }
		public System.Int32? OverallStatusID { get; set; }
		public System.Int32? CurrentStatusID { get; set; }
		public System.String Notes { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string CurrentStatusMaster_CurrentStatusDesc { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string EmployeeMaster2_EmployeeCode { get; set; }
		public string OverallStatu_OverallStatusDesc { get; set; }
		public string TaskMaster_TaskName { get; set; }
		public string TaskPriorityMaster_PriorityDesc { get; set; }
		public string TokenDetail_TokenKey { get; set; }
		public int TaskStatusLogs_Count { get; set; }
		public int TeamContribDetails_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< TaskAssignment,  TaskAssignmentDTO>> SELECT =
            x => new  TaskAssignmentDTO
            {
                TaskAssignmentID = x.TaskAssignmentID,
                TokenID = x.TokenID,
                TaskID = x.TaskID,
                TaskDescription = x.TaskDescription,
                TaskPriorityID = x.TaskPriorityID,
                DueDate = x.DueDate,
                LinkTask = x.LinkTask,
                AssignedOn = x.AssignedOn,
                AssignedByID = x.AssignedByID,
                OverallStatusID = x.OverallStatusID,
                CurrentStatusID = x.CurrentStatusID,
                Notes = x.Notes,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                CurrentStatusMaster_CurrentStatusDesc = x.CurrentStatusMaster.CurrentStatusDesc,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                EmployeeMaster2_EmployeeCode = x.EmployeeMaster2.EmployeeCode,
                OverallStatu_OverallStatusDesc = x.OverallStatu.OverallStatusDesc,
                TaskMaster_TaskName = x.TaskMaster.TaskName,
                TaskPriorityMaster_PriorityDesc = x.TaskPriorityMaster.PriorityDesc,
                TokenDetail_TokenKey = x.TokenDetail.TokenKey,
                TaskStatusLogs_Count = x.TaskStatusLogs.Count(),
                TeamContribDetails_Count = x.TeamContribDetails.Count(),
            };

	}
}