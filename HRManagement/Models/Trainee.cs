using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRManagement.Models
{
    public class Trainee 
    {
        
        [Key]
        [ForeignKey("User")]
        public string TraineeId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }

        [Display(Name = "Programming Language")]
        public string ProgrammingLanguage { get; set; }

        [Display(Name = "TOEIC Score")]
        public int ToeicScore { get; set; }

        public string Experience { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }
    }
}