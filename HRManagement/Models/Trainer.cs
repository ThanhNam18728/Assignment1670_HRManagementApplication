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
        public string Type { get; set; }
 
        [Display(Name = "Working Place")]
        public string WorkingPlace { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        
    }
}