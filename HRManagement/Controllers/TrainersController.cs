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
            return View();
        }
        public ActionResult ViewProfile(string id)
        {
            var currentTrainerId = User.Identity.GetUserId();
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == currentTrainerId);

            return View(trainerInDb);            
        }
        

        public ActionResult ViewAssignedCourses(string id)
        {
            var course = _context.CoursesTrainers.Where(t => t.TrainerId == id).Select(t => t.Course).ToList();

            return View(course);
        }
    }
}