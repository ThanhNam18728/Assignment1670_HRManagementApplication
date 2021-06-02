using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using HRManagement.ViewModels;

namespace HRManagement.Controllers
{
    public class AssignedCoursesController : Controller
    {
        private ApplicationDbContext _context;
        public AssignedCoursesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: AssignedCourses
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult CourseTrainer()
        {
            var trainerIndb = _context.Users.OfType<Trainer>().Include(t => t.Course).ToList();
            return View(trainerIndb);
        }
        public ActionResult CourseTrainee()
        {
            var traineeIndb = _context.Users.OfType<Trainee>().Include(t => t.Course).ToList();
            return View(traineeIndb);
        }
    }
}