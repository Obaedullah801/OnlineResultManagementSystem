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
    
    public partial class tblStudentProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStudentProfile()
        {
            this.tblMarksEntries = new HashSet<tblMarksEntry>();
            this.tblMarksheets = new HashSet<tblMarksheet>();
            this.tblSemesterResults = new HashSet<tblSemesterResult>();
        }
    
        public int student_profile_id { get; set; }
        [Display(Name = "Name")]
        public string student_name { get; set; }
        [Display(Name = "Photo")]
        public byte[] student_photo { get; set; }
        [Display(Name = "Father's name")]
        public string fathers_name { get; set; }
        [Display(Name = "Mother's name")]
        public string mothers_name { get; set; }
        [Display(Name = "Roll")]
        public int roll_no { get; set; }
        [Display(Name = "Reg No")]
        public int reg_no { get; set; }
        [Display(Name = "Degree")]
        public int degree_id { get; set; }
        [Display(Name = "Department")]
        public int department_id { get; set; }
        [Display(Name = "Semester")]
        public int semester_id { get; set; }
        [Display(Name = "Phone No")]
        public string phone_no { get; set; }
        [Display(Name = "Email Id")]
        public string email_id { get; set; }
    
        public virtual tblDegree tblDegree { get; set; }
        public virtual tblDepartment tblDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMarksEntry> tblMarksEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMarksheet> tblMarksheets { get; set; }
        public virtual tblSemester tblSemester { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSemesterResult> tblSemesterResults { get; set; }
    }
}
