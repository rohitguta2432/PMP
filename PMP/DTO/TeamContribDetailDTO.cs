
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
	public class TeamContribDetailDTO
    {
		public System.Int32 TeamContribID { get; set; }
		public System.Int32? TaskAssignmentID { get; set; }
		public System.Int32? EmployeeID { get; set; }
		public System.Int64? Hours { get; set; }
		public System.Decimal? Value { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string EmployeeMaster2_EmployeeCode { get; set; }
		public string TaskAssignment_TaskDescription { get; set; }

        public static System.Linq.Expressions.Expression<Func< TeamContribDetail,  TeamContribDetailDTO>> SELECT =
            x => new  TeamContribDetailDTO
            {
                TeamContribID = x.TeamContribID,
                TaskAssignmentID = x.TaskAssignmentID,
                EmployeeID = x.EmployeeID,
                Hours = x.Hours,
                Value = x.Value,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                EmployeeMaster2_EmployeeCode = x.EmployeeMaster2.EmployeeCode,
                TaskAssignment_TaskDescription = x.TaskAssignment.TaskDescription,
            };

	}
}