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
    
    public partial class AuthMapping
    {
        public int AuthID { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public Nullable<int> PageID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster1 { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual PageRulesMaster PageRulesMaster { get; set; }
    }
}
