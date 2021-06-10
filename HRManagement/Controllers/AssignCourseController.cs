using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using HRManagement.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRManagement.Controllers
{
    public class AssignCourseController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        public AssignCourseController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: AssignCourse
        [HttpGet]
        public ActionResult Index()
        {
            var coures = _context.Courses.ToList();
            return View(coures);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var users = _context.CoursesUsers
              .Where(t => t.CourseId == id)
              .Select(t => t.Trainer)
              .ToList();

            ViewBag.CourseId = id;

            return View(users);
        }

        [HttpGet]
        public ActionResult AssignCourseTrainer(int id)
        {
            var trainer = _context.Users.OfType<Trainer>().ToList();

            var trainersInCourse = _context.CoursesUsers
              .Where(t => t.CourseId == id)
              .Select(t => t.Trainer)
              .ToList();

            var VModel = new CourseTrainersViewModel();

            if (trainersInCourse == null)
            {
                VModel.CourseId = id;
                VModel.Trainers = trainer;

                return View(VModel);
            }

            var viewModel = new CourseTrainersViewModel
            {
                CourseId = id,
                Trainers = trainer
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignCourseTrainer(CoursesUsers model)
        {
            var courseUser = new CoursesUsers
            {
                CourseId = model.CourseId,
                TrainerId = model.TrainerId
            };

            _context.CoursesUsers.Add(courseUser);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}