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
    
    public partial class ActualExpenseDetail
    {
        public int ActualExpenseID { get; set; }
        public Nullable<int> Units { get; set; }
        public Nullable<decimal> UnitRate { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> PhaseExpenseID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster1 { get; set; }
        public virtual PhaseExpenseDetail PhaseExpenseDetail { get; set; }
    }
}
