using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models
{
    public class Trainer : ApplicationUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Working Place")]
        public string WorkingPlace { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}