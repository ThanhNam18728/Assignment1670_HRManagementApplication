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
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public string Education { get; set; }
        [Required]
        [Display(Name = "Programming Language")]
        public string ProgrammingLanguage { get; set; }
        [Required]
        [Display(Name = "TOEIC Score")]
        public int ToeicScore { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Location { get; set; }
    }
}