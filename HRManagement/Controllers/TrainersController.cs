using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using HRManagement.ViewModels;
using Microsoft.AspNet.Identity;

namespace HRManagement.Controllers
{
    [Authorize(Roles ="Trainer")]
    public class TrainersController : Controller
    {
        private ApplicationDbContext _context;
        public TrainersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Trainers       
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult ViewProfile(string id)
        {
            var currentTrainerId = User.Identity.GetUserId();
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == currentTrainerId);

            return View(trainerInDb);            
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            var currentUserId = User.Identity.GetUserId();
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == currentUserId);
            return View(trainerInDb);
        }

        [HttpPost]
        public ActionResult EditProfile(Trainer trainer)
        {
            var currentUserId = User.Identity.GetUserId();
            var trainerInDb = _context.Trainers.SingleOrDefault(c => c.TrainerId == currentUserId);

            trainerInDb.EmailAddress = trainer.EmailAddress;
            trainerInDb.FullName = trainer.FullName;
            trainerInDb.DateOfBirth = trainer.DateOfBirth;
            trainerInDb.Type = trainer.Type;
            trainerInDb.WorkingPlace = trainer.WorkingPlace;

            _context.SaveChanges();
            return RedirectToAction("ViewProfile", "Trainers");
        }


        public ActionResult ViewAssignedCourses()
        {
            var currentTrainerId = User.Identity.GetUserId();
            var course = _context.CoursesTrainers.Where(t => t.TrainerId == currentTrainerId).Select(t => t.Course).ToList();

            return View(course);
        }       
    }
}