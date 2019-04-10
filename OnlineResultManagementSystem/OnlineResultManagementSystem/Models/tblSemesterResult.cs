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
    
    public partial class tblSemesterResult
    {
        public int semester_result_id { get; set; }
        [Display(Name = "Student name")]
        public int student_profile_id { get; set; }
        [Display(Name = "Roll")]
        public int roll_no { get; set; }
        [Display(Name = "Reg No")]
        public int reg_no { get; set; }
        [Display(Name = "Total Marks")]
        public int total_marks { get; set; }
        [Display(Name = "Obtained Total Marks")]
        public int obtained_total_marks { get; set; }
        [Display(Name = "Letter grade")]
        public string letter_grade { get; set; }
        [Display(Name = "Grade Point")]
        public decimal grade_point { get; set; }
        [Display(Name = "Division")]
        public string division_class { get; set; }
    
        public virtual tblStudentProfile tblStudentProfile { get; set; }
    }
}