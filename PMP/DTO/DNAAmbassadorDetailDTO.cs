﻿
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
	public class DNAAmbassadorDetailDTO
    {
		public System.Int32 AmbassadorsID { get; set; }
		public System.Int32? ProjectID { get; set; }
		public System.String AmbassadorsDesc { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public string EmployeeMaster_EmployeeCode { get; set; }
		public string EmployeeMaster1_EmployeeCode { get; set; }
		public string ProjectDetail_ProjectDesc { get; set; }

        public static System.Linq.Expressions.Expression<Func< DNAAmbassadorDetail,  DNAAmbassadorDetailDTO>> SELECT =
            x => new  DNAAmbassadorDetailDTO
            {
                AmbassadorsID = x.AmbassadorsID,
                ProjectID = x.ProjectID,
                AmbassadorsDesc = x.AmbassadorsDesc,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                EmployeeMaster_EmployeeCode = x.EmployeeMaster.EmployeeCode,
                EmployeeMaster1_EmployeeCode = x.EmployeeMaster1.EmployeeCode,
                ProjectDetail_ProjectDesc = x.ProjectDetail.ProjectDesc,
            };

	}
}