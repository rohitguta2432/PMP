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
    
    public partial class TaskMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskMaster()
        {
            this.TaskAssignments = new HashSet<TaskAssignment>();
        }
    
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> Stage { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual EmployeeMaster EmployeeMaster { get; set; }
        public virtual EmployeeMaster EmployeeMaster1 { get; set; }
        public virtual StageMaster StageMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
    }
}
