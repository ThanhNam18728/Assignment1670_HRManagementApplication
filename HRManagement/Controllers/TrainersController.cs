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
            var trainerInDb = _context.Users.ToList();

            if (trainerInDb == null) return HttpNotFound();
            return View(trainerInDb);
        }
        public ActionResult Details(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);
            return View(trainerInDb);
        }


        
        public ActionResult Delete(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);

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