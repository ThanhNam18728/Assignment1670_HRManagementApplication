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
    [Authorize(Roles ="Staff")]
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

        /// <summary>
        /// This function is used to display a list of trainers in course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Details(int id)
        {
            var users = _context.CoursesTrainers
              .Where(t => t.CourseId == id)
              .Select(t => t.Trainer)
              .ToList();
            if (users == null) return HttpNotFound();

            ViewBag.CourseId = id;

            return View(users);
        }


        /// <summary>
        /// This function is used to assign a Trainer to Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AssignCourseTrainer(int id)
        {
            var trainer = _context.Trainers.ToList();

            var trainersInCourse = _context.CoursesTrainers
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
        public ActionResult AssignCourseTrainer(CoursesTrainers model)
        {
            var courseUser = new CoursesTrainers
            {
                CourseId = model.CourseId,
                TrainerId = model.TrainerId
            };

            _context.CoursesTrainers.Add(courseUser);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        /// <summary>
        ///  Remove Trainer from Course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RemoveTrainer(int id, string trainerId)
        {
            var trainerInCourse = _context.CoursesTrainers
              .SingleOrDefault(t => t.CourseId == id && t.TrainerId == trainerId);

            if (trainerInCourse == null) return HttpNotFound();

            _context.CoursesTrainers.Remove(trainerInCourse);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }


        /// <summary>
        /// This function is used to display a list of trainees in course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListTrainees(int id)
        {
            var trainees = _context.CoursesTrainees
              .Where(t => t.CourseId == id)
              .Select(t => t.Trainee)
              .ToList();

            ViewBag.CourseId = id;

            return View(trainees);
        }


        /// <summary>
        /// This function is used to assign a Trainee to Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AssignCourseTrainee(int id)
        {
            var trainee = _context.Trainees.ToList();

            var traineesInCourse = _context.CoursesTrainees
              .Where(t => t.CourseId == id)
              .Select(t => t.Trainee)
              .ToList();

            var VModel = new CourseTraineesViewModel();

            if (traineesInCourse == null)
            {
                VModel.CourseId = id;
                VModel.Trainees = trainee;

                return View(VModel);
            }

            var viewModel = new CourseTraineesViewModel
            {
                CourseId = id,
                Trainees = trainee
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignCourseTrainee(CoursesTrainees model)
        {
            var courseTrainees = new CoursesTrainees
            {
                CourseId = model.CourseId,
                TraineeId = model.TraineeId
            };

            _context.CoursesTrainees.Add(courseTrainees);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Remove Trainee from Course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="traineeId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RemoveTrainee(int id, string traineeId)
        {
            var traineeInCourse = _context.CoursesTrainees
              .SingleOrDefault(t => t.CourseId == id && t.TraineeId == traineeId);

            if (traineeInCourse == null) return HttpNotFound();

            _context.CoursesTrainees.Remove(traineeInCourse);
            _context.SaveChanges();

            return RedirectToAction("ListTrainees", new { id = id });
        }


    }
}