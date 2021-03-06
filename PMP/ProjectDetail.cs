//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectDetail()
        {
            this.DNAAmbassadorDetails = new HashSet<DNAAmbassadorDetail>();
            this.DNAManagerDetails = new HashSet<DNAManagerDetail>();
            this.ExpenseDetails = new HashSet<ExpenseDetail>();
            this.ProjectAccountsDetails = new HashSet<ProjectAccountsDetail>();
        }
    
        public int ProjectID { get; set; }
        public Nullable<int> TokenID { get; set; }
        public string ProjectDesc { get; set; }
        public Nullable<int> IndustryID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> ProductCatID { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<System.DateTime> ProposalDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual BrandMaster BrandMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DNAAmbassadorDetail> DNAAmbassadorDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DNAManagerDetail> DNAManagerDetails { get; set; }
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster1 { get; set; }
        public virtual EmployeeMaster EmployeeMaster2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpenseDetail> ExpenseDetails { get; set; }
        public virtual IndustryMaster IndustryMaster { get; set; }
        public virtual ProductCatMaster ProductCatMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectAccountsDetail> ProjectAccountsDetails { get; set; }
        public virtual TokenDetail TokenDetail { get; set; }
        public virtual ClientMaster ClientMaster { get; set; }
    }
}
