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
            var trainersInDb = _context.Trainers.ToList();
            return View(trainersInDb);
        }
        public ActionResult Details(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.Id == id);
            return View(trainerInDb);
        }


        public ActionResult Update(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.Id == id);
            if (trainerInDb == null) return HttpNotFound();

            return View(trainerInDb);
        }
        [HttpPost]
        public ActionResult Update(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
               return View();
            }

            var TrainerInDb = _context.Trainers.SingleOrDefault(t => t.Id == trainer.Id);
            {
                TrainerInDb.FullName = trainer.FullName;
                TrainerInDb.DateOfBirth = trainer.DateOfBirth;
                TrainerInDb.WorkingPlace = trainer.WorkingPlace;
                TrainerInDb.EmailAddress = trainer.EmailAddress;
                TrainerInDb.Type = trainer.Type;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.Id == id);

            if (trainerInDb == null) return HttpNotFound();

            _context.Trainers.Remove(trainerInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }   
        
        public ActionResult ViewAssignedCourses(string id)
        {
            var course = _context.CoursesTrainers.Where(t => t.TrainerId == id).Select(t => t.Course).ToList();
           
            return View(course);
        }
    }
}