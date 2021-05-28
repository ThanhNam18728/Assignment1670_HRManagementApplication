using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models;

namespace HRManagement.ViewModels
{
    public class CourseCategoryViewModels
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}