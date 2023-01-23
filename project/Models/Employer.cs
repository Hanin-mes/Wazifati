//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employer()
        {
            this.JobPosts = new HashSet<JobPost>();
        }
    
        public int EmployerID { get; set; }
        public int UserID { get; set; }
        public string Position { get; set; }
        public string Website { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public System.DateTime SystemDate { get; set; }
    
        public virtual SystemUser SystemUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPost> JobPosts { get; set; }
    }
}
