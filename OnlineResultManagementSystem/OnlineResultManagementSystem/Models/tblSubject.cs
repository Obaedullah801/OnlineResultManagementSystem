//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineResultManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tblSubject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSubject()
        {
            this.tblMarksEntries = new HashSet<tblMarksEntry>();
        }
         
        public int subject_id { get; set; }
        [Display(Name = "Subject name")]
        public string subject_name { get; set; }
        [Display(Name = "Subject code")]
        public int subject_code { get; set; }
        [Display(Name = "Full Marks")]
        public int full_marks { get; set; }
        [Display(Name = "Credit")]
        public Nullable<decimal> credit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMarksEntry> tblMarksEntries { get; set; }
    }
}