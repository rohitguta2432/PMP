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
    
    public partial class ExpenseDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseDetail()
        {
            this.PhaseExpenseDetails = new HashSet<PhaseExpenseDetail>();
        }
    
        public int ExpenseID { get; set; }
        public Nullable<int> PhaseID { get; set; }
        public Nullable<int> ResearchTypeID { get; set; }
        public Nullable<int> MethodID { get; set; }
        public string TargetAud { get; set; }
        public Nullable<int> Units { get; set; }
        public Nullable<decimal> FeePerUnit { get; set; }
        public Nullable<decimal> TotalFee { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public Nullable<int> TimingDays { get; set; }
        public Nullable<decimal> EstMargin { get; set; }
        public Nullable<int> ProjectID { get; set; }
        public Nullable<decimal> TotalExpense { get; set; }
        public Nullable<decimal> EmployeeContrib { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual CurrencyDetail CurrencyDetail { get; set; }
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster1 { get; set; }
        public virtual MethodologyMaster MethodologyMaster { get; set; }
        public virtual PhaseMaster PhaseMaster { get; set; }
        public virtual ProjectDetail ProjectDetail { get; set; }
        public virtual ResearchTypeMaster ResearchTypeMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhaseExpenseDetail> PhaseExpenseDetails { get; set; }
    }
}
