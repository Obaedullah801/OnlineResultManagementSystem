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
    
    public partial class tblCollege
    {
        public int college_id { get; set; }
        [Display(Name = "College Name")]
        public string college_name { get; set; }
        public int college_code { get; set; }
        public byte[] college_logo { get; set; }
        public string college_address { get; set; }
    }
}
