using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using System.Data.Entity;
using HRManagement.ViewModels;
using Microsoft.Ajax.Utilities;

namespace HRManagement.Controllers
{
	[Authorize(Roles ="Staff")]
    public class CoursesController : Controller
    {
		private ApplicationDbContext _context;
		public CoursesController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Courses
		public ActionResult Index(string searchString)
		{
			var coursesInDb = _context.Courses.Include(t => t.Category).ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
				coursesInDb = _context.Courses.Where(c => c.Name.Contains(searchString)).ToList();
            }
			return View(coursesInDb);
		}

		public ActionResult Create()
		{
			var viewModel = new CourseCategoryViewModels()
			{
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]

		public ActionResult Create(Course course)
		{		
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Create");
			}
			else
			{
				var newCourse = new Course()
				{
					Name = course.Name,
					Description = course.Description,
					CategoryId = course.CategoryId
				};
				_context.Courses.Add(newCourse);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}

		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
			if (courseInDb == null) return HttpNotFound();
			var viewModel = new CourseCategoryViewModels()
			{
				Course = courseInDb,
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Course course)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CourseCategoryViewModels()
				{
					Course = course,
					Categories = _context.Categories.ToList()
				};
				return View(viewModel);
			}
			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == course.Id);
			courseInDb.Name = course.Name;
			courseInDb.Description = course.Description;
			courseInDb.CategoryId = course.CategoryId;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)

		{

			var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);

			if (courseInDb == null) return HttpNotFound();

			_context.Courses.Remove(courseInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}	
	}
}