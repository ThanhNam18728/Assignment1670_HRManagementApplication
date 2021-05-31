using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Models
{
    public class Trainer : User
    {
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