using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using Microsoft.Ajax.Utilities;

namespace HRManagement.Controllers
{
    public class StaffController : Controller
    {
        private ApplicationDbContext _context;
        public StaffController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTrainees(string searchString)
        {

            var traineeInDb = _context.Trainees.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                traineeInDb = _context.Trainees
                .Where(m => m.FullName.Contains(searchString))
                .ToList();
            }

            return View(traineeInDb);
        }

        [HttpGet]
        public ActionResult UpdateTrainee(string id)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);
            if (traineeInDb == null) return HttpNotFound();
            return View(traineeInDb);
        }

        [HttpPost]
        public ActionResult UpdateTrainee(Trainee trainee)
        {
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == trainee.TraineeId);
            {
                traineeInDb.FullName = trainee.FullName;
                traineeInDb.DateOfBirth = trainee.DateOfBirth;
                traineeInDb.Department = trainee.Department;
                traineeInDb.Education = trainee.Education;
                traineeInDb.ProgrammingLanguage = trainee.ProgrammingLanguage;
                traineeInDb.ToeicScore = trainee.ToeicScore;
                traineeInDb.Experience = trainee.Experience;
                traineeInDb.Location = trainee.Location;
            }

            _context.SaveChanges();

            return RedirectToAction("ListTrainees");
        }
    }
}