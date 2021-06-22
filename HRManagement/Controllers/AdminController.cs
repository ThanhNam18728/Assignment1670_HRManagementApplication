using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRManagement.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public AdminController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListTrainers(string searchString)
        {

            var trainerInDb = _context.Trainers.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                trainerInDb = _context.Trainers
                .Where(m => m.FullName.Contains(searchString))
                .ToList();
            }

            return View(trainerInDb);
        }
        public ActionResult UpdateTrainer(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);
            if (trainerInDb == null) return HttpNotFound();

            return View(trainerInDb);
        }
        [HttpPost]
        public ActionResult UpdateTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var TrainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == trainer.TrainerId);
            {
                TrainerInDb.FullName = trainer.FullName;
                TrainerInDb.DateOfBirth = trainer.DateOfBirth;
                TrainerInDb.WorkingPlace = trainer.WorkingPlace;
                TrainerInDb.EmailAddress = trainer.EmailAddress;
                TrainerInDb.Type = trainer.Type;
            }
            _context.SaveChanges();
            return RedirectToAction("ListTrainers");
        }

        public ActionResult DeleteTrainer(string id)
        {
            var trainerInDb = _context.Trainers.SingleOrDefault(t => t.TrainerId == id);

            if (trainerInDb == null) return HttpNotFound();

            _context.Trainers.Remove(trainerInDb);
            _context.SaveChanges();
            return RedirectToAction("ListTrainers");
        }

        public ActionResult ListStaffs(string searchString)
        {

            var staffInDb = _context.Staffs.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                staffInDb = _context.Staffs
                .Where(m => m.FullName.Contains(searchString))
                .ToList();
            }

            return View(staffInDb);
        }

        public ActionResult UpdateStaff(string id)
        {
            var staffInDb = _context.Staffs.SingleOrDefault(t => t.StaffId == id);
            if (staffInDb == null) return HttpNotFound();

            return View(staffInDb);
        }
        [HttpPost]
        public ActionResult UpdateStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var staffInDb = _context.Staffs.SingleOrDefault(t => t.StaffId == staff.StaffId);
            {
                staffInDb.FullName = staff.FullName;
                staffInDb.DateOfBirth = staff.DateOfBirth;
            }
            _context.SaveChanges();
            return RedirectToAction("ListStaffs");
        }
    }
}