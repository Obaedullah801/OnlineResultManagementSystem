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
    
    public partial class tblMarksEntry
    {
        public int marks_entry_id { get; set; }
        [Display(Name = "Student name")]
        public int student_profile_id { get; set; }
        [Display(Name = "Degree")]
        public int degree_id { get; set; }
        [Display(Name = "Department")]
        public int department_id { get; set; }
        [Display(Name = "Semester")]
        public int semester_id { get; set; }
        [Display(Name = "Roll")]
        public int roll_no { get; set; }
        [Display(Name = "Reg No")]
        public int reg_no { get; set; }
        [Display(Name = "Subject")]
        public int subject_id { get; set; }
        [Display(Name = "Full Marks")]
        public int full_marks { get; set; }
        [Display(Name = "obtained Marks")]
        public int obtained_marks { get; set; }

    
        public virtual tblDegree tblDegree { get; set; }
        public virtual tblDegree tblDegree1 { get; set; }
        public virtual tblDepartment tblDepartment { get; set; }
        public virtual tblStudentProfile tblStudentProfile { get; set; }
        public virtual tblSubject tblSubject { get; set; }
    }
}
