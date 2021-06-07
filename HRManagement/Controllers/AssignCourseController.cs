using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;

namespace HRManagement.Controllers
{
    public class AssignCourseController : Controller
    {
        private ApplicationDbContext _context;
        public AssignCourseController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: AssignCourse
        [HttpGet]
        public ActionResult Index()
        {
            var coures = _context.Courses.ToList();
            return View(coures);
        }
    }
}