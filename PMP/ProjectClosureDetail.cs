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
    
    public partial class ProjectClosureDetail
    {
        public int ProjectClosureID { get; set; }
        public Nullable<int> TokenID { get; set; }
        public Nullable<int> DocumentID { get; set; }
        public Nullable<int> CRPStatus { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual CRPStatu CRPStatu { get; set; }
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster1 { get; set; }
        public virtual TokenDetail TokenDetail { get; set; }
        public virtual DocumentDetail DocumentDetail { get; set; }
    }
}
