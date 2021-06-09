using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagement.Models;

namespace HRManagement.ViewModels
{
    public class CourseUsersViewModel 
    {
        public int CourseId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }

    }
}