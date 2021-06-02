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
        public ActionResult Index(int id)
        {
            var trainersInCourse = _context.Users.OfType<Trainer>().Where(t => t.CourseId == id).ToList();
            var traineesInCourse = _context.Users.OfType<Trainee>().Where(t => t.CourseId == id).ToList();
            var CategoryOfCourse = _context.Categories.Where(m => m.Id == id).ToList();

            var UsersCourseView = new TrainersTraineesCourseViewModel()
            {
                Trainers = trainersInCourse,
                Trainees = traineesInCourse,
                Course = _context.Courses.SingleOrDefault(t => t.Id == id)
            };
            return View(UsersCourseView);
        }
        
    }
}