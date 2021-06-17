using HRManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HRManagement.Controllers
{

    public class RolesController : Controller
    {
        // GET: Roles
        private ApplicationDbContext _context;

        public RolesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Roles = _context.Roles.ToList();
            return View(Roles);
        }
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}