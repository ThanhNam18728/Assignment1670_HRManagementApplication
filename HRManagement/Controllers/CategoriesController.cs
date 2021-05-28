using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;

namespace HRManagement.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();           
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }          
            var newCategory = new Category()
            {
                Name = category.Name,
                Description = category.Description,
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryInDb == null) return HttpNotFound();

            return View(categoryInDb);
        }

        public ActionResult Delete(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);

            if (categoryInDb == null) return HttpNotFound();

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var taskInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);

            taskInDb.Name = category.Name;
            taskInDb.Description = category.Description;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}