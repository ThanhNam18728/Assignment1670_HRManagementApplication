using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRManagement.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should not be Empty")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description should not be Empty")]
        [Display(Name = "Category Description")]
        public string Description { get; set; }
    }
}