using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManagement.Models
{
    public class Trainer
    {
        public ApplicationUser User { get; set; }
        [Key]
        [ForeignKey("User")]
        public string TrainerId { get; set; }
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
        
    }
}