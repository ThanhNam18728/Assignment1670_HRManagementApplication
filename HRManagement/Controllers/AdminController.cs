using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
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
        [HttpGet]
        public ActionResult CreateTrainer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTrainer(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = _userManager.Create(user, model.Password);
            if(result.Succeeded)
            {
                _userManager.AddToRole(user.Id, model.Role);
                _context.SaveChanges();
            }
            return View(model);
        }
    }
}