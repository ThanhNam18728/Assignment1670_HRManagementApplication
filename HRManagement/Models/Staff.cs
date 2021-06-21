using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRManagement.Models
{
    public class Staff
    {
        public ApplicationUser User { get; set; }
        [Key]
        [ForeignKey("User")]
        public string StaffId { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }      
    }
}