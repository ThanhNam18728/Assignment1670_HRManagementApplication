using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManagement.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should not be Empty !!!")]
        [StringLength(255)]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description should not be Empty !!!")]
        public string Description { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}