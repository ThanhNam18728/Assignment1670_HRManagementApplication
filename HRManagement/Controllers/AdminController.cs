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
    }
}