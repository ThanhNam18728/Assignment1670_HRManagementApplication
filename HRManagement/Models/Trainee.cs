using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManagement.Models
{
    public class Trainee : User
    {       
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