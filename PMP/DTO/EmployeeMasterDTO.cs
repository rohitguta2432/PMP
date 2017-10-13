
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
	public class EmployeeMasterDTO
    {
		public System.Int32 EmployeeID { get; set; }
		public System.String EmployeeCode { get; set; }
		public System.String FirstName { get; set; }
		public System.String LastName { get; set; }
		public System.String MiddleName { get; set; }
		public System.String ContactNumber { get; set; }
		public System.String EmailID { get; set; }
		public System.String Address { get; set; }
		public System.Int32? DesignationID { get; set; }
		public System.Int32? DepartmentID { get; set; }
		public System.Boolean? IsActive { get; set; }
		public System.Int32? CreatedBy { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public System.Int32? ModifiedBy { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public int ActualExpenseDetails_Count { get; set; }
		public int ActualExpenseDetails1_Count { get; set; }
		public int AuthMappings_Count { get; set; }
		public int AuthMappings1_Count { get; set; }
		public int BrandMasters_Count { get; set; }
		public int BrandMasters1_Count { get; set; }
		public int ChannelMasters_Count { get; set; }
		public int ChannelMasters1_Count { get; set; }
		public int ClientMasters_Count { get; set; }
		public int ClientMasters1_Count { get; set; }
		public int ContactPersonMasters_Count { get; set; }
		public int ContactPersonMasters1_Count { get; set; }
		public int CRPStatus_Count { get; set; }
		public int CRPStatus1_Count { get; set; }
		public int CurrencyDetails_Count { get; set; }
		public int CurrencyDetails1_Count { get; set; }
		public int CurrencySettings_Count { get; set; }
		public int CurrencySettings1_Count { get; set; }
		public int CurrentStatusMasters_Count { get; set; }
		public int CurrentStatusMasters1_Count { get; set; }
		public int Departments_Count { get; set; }
		public int Departments1_Count { get; set; }
		public string Department_DepartmentDesc { get; set; }
		public int Designations_Count { get; set; }
		public int Designations1_Count { get; set; }
		public string Designation_DesignationDesc { get; set; }
		public int DNAAmbassadorDetails_Count { get; set; }
		public int DNAAmbassadorDetails1_Count { get; set; }
		public int DNAManagerDetails_Count { get; set; }
		public int DNAManagerDetails1_Count { get; set; }
		public int DocumentDetails_Count { get; set; }
		public int DocumentDetails1_Count { get; set; }
		public int EmployeeMaster1_Count { get; set; }
		public string EmployeeMaster2_EmployeeCode { get; set; }
		public int EmployeeMaster11_Count { get; set; }
		public string EmployeeMaster3_EmployeeCode { get; set; }
		public int EstimatedExpenseDetails_Count { get; set; }
		public int EstimatedExpenseDetails1_Count { get; set; }
		public int ExpenseDetails_Count { get; set; }
		public int ExpenseDetails1_Count { get; set; }
		public int ExpenseHeadMasters_Count { get; set; }
		public int ExpenseHeadMasters1_Count { get; set; }
		public int ExpenseTypeMasters_Count { get; set; }
		public int ExpenseTypeMasters1_Count { get; set; }
		public int IndustryMasters_Count { get; set; }
		public int IndustryMasters1_Count { get; set; }
		public int InitialProjects_Count { get; set; }
		public int InitialProjects1_Count { get; set; }
		public int InquiryTypeMasters_Count { get; set; }
		public int InquiryTypeMasters1_Count { get; set; }
		public int MethodologyMasters_Count { get; set; }
		public int MethodologyMasters1_Count { get; set; }
		public int OverallStatus_Count { get; set; }
		public int OverallStatus1_Count { get; set; }
		public int PageRulesMasters_Count { get; set; }
		public int PageRulesMasters1_Count { get; set; }
		public int PhaseExpenseDetails_Count { get; set; }
		public int PhaseExpenseDetails1_Count { get; set; }
		public int PhaseMasters_Count { get; set; }
		public int PhaseMasters1_Count { get; set; }
		public int ProductCatMasters_Count { get; set; }
		public int ProductCatMasters1_Count { get; set; }
		public int ProjectAccountsDetails_Count { get; set; }
		public int ProjectAccountsDetails1_Count { get; set; }
		public int ProjectClosureDetails_Count { get; set; }
		public int ProjectClosureDetails1_Count { get; set; }
		public int ProjectDetails_Count { get; set; }
		public int ProjectDetails1_Count { get; set; }
		public int ProjectFundings_Count { get; set; }
		public int ProjectFundings1_Count { get; set; }
		public int ResearchTypeMasters_Count { get; set; }
		public int ResearchTypeMasters1_Count { get; set; }
		public int SourceMasters_Count { get; set; }
		public int SourceMasters1_Count { get; set; }
		public int SystemSettings_Count { get; set; }
		public int SystemSettings1_Count { get; set; }
		public int TaskAssignments_Count { get; set; }
		public int TaskAssignments1_Count { get; set; }
		public int TaskMasters_Count { get; set; }
		public int TaskMasters1_Count { get; set; }
		public int TaskPriorityMasters_Count { get; set; }
		public int TaskPriorityMasters1_Count { get; set; }
		public int TaskStatusLogs_Count { get; set; }
		public int TaskStatusLogs1_Count { get; set; }
		public int TeamContribDetails_Count { get; set; }
		public int TeamContribDetails1_Count { get; set; }
		public int TokenDetails_Count { get; set; }
		public int VendorMasters_Count { get; set; }
		public int VendorMasters1_Count { get; set; }
		public int ProjectDetails2_Count { get; set; }
		public int TaskAssignments2_Count { get; set; }
		public int TeamContribDetails2_Count { get; set; }
		public int TokenDetails1_Count { get; set; }
		public int TokenDetails2_Count { get; set; }

        public static System.Linq.Expressions.Expression<Func< EmployeeMaster,  EmployeeMasterDTO>> SELECT =
            x => new  EmployeeMasterDTO
            {
                EmployeeID = x.EmployeeID,
                EmployeeCode = x.EmployeeCode,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                ContactNumber = x.ContactNumber,
                EmailID = x.EmailID,
                Address = x.Address,
                DesignationID = x.DesignationID,
                DepartmentID = x.DepartmentID,
                IsActive = x.IsActive,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ActualExpenseDetails_Count = x.ActualExpenseDetails.Count(),
                ActualExpenseDetails1_Count = x.ActualExpenseDetails1.Count(),
                AuthMappings_Count = x.AuthMappings.Count(),
                AuthMappings1_Count = x.AuthMappings1.Count(),
                BrandMasters_Count = x.BrandMasters.Count(),
                BrandMasters1_Count = x.BrandMasters1.Count(),
                ChannelMasters_Count = x.ChannelMasters.Count(),
                ChannelMasters1_Count = x.ChannelMasters1.Count(),
                ClientMasters_Count = x.ClientMasters.Count(),
                ClientMasters1_Count = x.ClientMasters1.Count(),
                ContactPersonMasters_Count = x.ContactPersonMasters.Count(),
                ContactPersonMasters1_Count = x.ContactPersonMasters1.Count(),
                CRPStatus_Count = x.CRPStatus.Count(),
                CRPStatus1_Count = x.CRPStatus1.Count(),
                CurrencyDetails_Count = x.CurrencyDetails.Count(),
                CurrencyDetails1_Count = x.CurrencyDetails1.Count(),
                CurrencySettings_Count = x.CurrencySettings.Count(),
                CurrencySettings1_Count = x.CurrencySettings1.Count(),
                CurrentStatusMasters_Count = x.CurrentStatusMasters.Count(),
                CurrentStatusMasters1_Count = x.CurrentStatusMasters1.Count(),
                Departments_Count = x.Departments.Count(),
                Departments1_Count = x.Departments1.Count(),
                Department_DepartmentDesc = x.Department.DepartmentDesc,
                Designations_Count = x.Designations.Count(),
                Designations1_Count = x.Designations1.Count(),
                Designation_DesignationDesc = x.Designation.DesignationDesc,
                DNAAmbassadorDetails_Count = x.DNAAmbassadorDetails.Count(),
                DNAAmbassadorDetails1_Count = x.DNAAmbassadorDetails1.Count(),
                DNAManagerDetails_Count = x.DNAManagerDetails.Count(),
                DNAManagerDetails1_Count = x.DNAManagerDetails1.Count(),
                DocumentDetails_Count = x.DocumentDetails.Count(),
                DocumentDetails1_Count = x.DocumentDetails1.Count(),
                EmployeeMaster1_Count = x.EmployeeMaster1.Count(),
                EmployeeMaster2_EmployeeCode = x.EmployeeMaster2.EmployeeCode,
                EmployeeMaster11_Count = x.EmployeeMaster11.Count(),
                EmployeeMaster3_EmployeeCode = x.EmployeeMaster3.EmployeeCode,
                EstimatedExpenseDetails_Count = x.EstimatedExpenseDetails.Count(),
                EstimatedExpenseDetails1_Count = x.EstimatedExpenseDetails1.Count(),
                ExpenseDetails_Count = x.ExpenseDetails.Count(),
                ExpenseDetails1_Count = x.ExpenseDetails1.Count(),
                ExpenseHeadMasters_Count = x.ExpenseHeadMasters.Count(),
                ExpenseHeadMasters1_Count = x.ExpenseHeadMasters1.Count(),
                ExpenseTypeMasters_Count = x.ExpenseTypeMasters.Count(),
                ExpenseTypeMasters1_Count = x.ExpenseTypeMasters1.Count(),
                IndustryMasters_Count = x.IndustryMasters.Count(),
                IndustryMasters1_Count = x.IndustryMasters1.Count(),
                InitialProjects_Count = x.InitialProjects.Count(),
                InitialProjects1_Count = x.InitialProjects1.Count(),
                InquiryTypeMasters_Count = x.InquiryTypeMasters.Count(),
                InquiryTypeMasters1_Count = x.InquiryTypeMasters1.Count(),
                MethodologyMasters_Count = x.MethodologyMasters.Count(),
                MethodologyMasters1_Count = x.MethodologyMasters1.Count(),
                OverallStatus_Count = x.OverallStatus.Count(),
                OverallStatus1_Count = x.OverallStatus1.Count(),
                PageRulesMasters_Count = x.PageRulesMasters.Count(),
                PageRulesMasters1_Count = x.PageRulesMasters1.Count(),
                PhaseExpenseDetails_Count = x.PhaseExpenseDetails.Count(),
                PhaseExpenseDetails1_Count = x.PhaseExpenseDetails1.Count(),
                PhaseMasters_Count = x.PhaseMasters.Count(),
                PhaseMasters1_Count = x.PhaseMasters1.Count(),
                ProductCatMasters_Count = x.ProductCatMasters.Count(),
                ProductCatMasters1_Count = x.ProductCatMasters1.Count(),
                ProjectAccountsDetails_Count = x.ProjectAccountsDetails.Count(),
                ProjectAccountsDetails1_Count = x.ProjectAccountsDetails1.Count(),
                ProjectClosureDetails_Count = x.ProjectClosureDetails.Count(),
                ProjectClosureDetails1_Count = x.ProjectClosureDetails1.Count(),
                ProjectDetails_Count = x.ProjectDetails.Count(),
                ProjectDetails1_Count = x.ProjectDetails1.Count(),
                ProjectFundings_Count = x.ProjectFundings.Count(),
                ProjectFundings1_Count = x.ProjectFundings1.Count(),
                ResearchTypeMasters_Count = x.ResearchTypeMasters.Count(),
                ResearchTypeMasters1_Count = x.ResearchTypeMasters1.Count(),
                SourceMasters_Count = x.SourceMasters.Count(),
                SourceMasters1_Count = x.SourceMasters1.Count(),
                SystemSettings_Count = x.SystemSettings.Count(),
                SystemSettings1_Count = x.SystemSettings1.Count(),
                TaskAssignments_Count = x.TaskAssignments.Count(),
                TaskAssignments1_Count = x.TaskAssignments1.Count(),
                TaskMasters_Count = x.TaskMasters.Count(),
                TaskMasters1_Count = x.TaskMasters1.Count(),
                TaskPriorityMasters_Count = x.TaskPriorityMasters.Count(),
                TaskPriorityMasters1_Count = x.TaskPriorityMasters1.Count(),
                TaskStatusLogs_Count = x.TaskStatusLogs.Count(),
                TaskStatusLogs1_Count = x.TaskStatusLogs1.Count(),
                TeamContribDetails_Count = x.TeamContribDetails.Count(),
                TeamContribDetails1_Count = x.TeamContribDetails1.Count(),
                TokenDetails_Count = x.TokenDetails.Count(),
                VendorMasters_Count = x.VendorMasters.Count(),
                VendorMasters1_Count = x.VendorMasters1.Count(),
                ProjectDetails2_Count = x.ProjectDetails2.Count(),
                TaskAssignments2_Count = x.TaskAssignments2.Count(),
                TeamContribDetails2_Count = x.TeamContribDetails2.Count(),
                TokenDetails1_Count = x.TokenDetails1.Count(),
                TokenDetails2_Count = x.TokenDetails2.Count(),
            };
       
	}
}