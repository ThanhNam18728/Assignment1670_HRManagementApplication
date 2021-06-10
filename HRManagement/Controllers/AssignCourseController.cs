﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRManagement.Models;
using HRManagement.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRManagement.Controllers
{
    public class AssignCourseController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        public AssignCourseController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(
        new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        // GET: AssignCourse
        [HttpGet]
        public ActionResult Index()
        {
            var coures = _context.Courses.ToList();
            return View(coures);
        }

        /// <summary>
        /// This function is used to display a list of trainers in course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Details(int id)
        {
            var users = _context.CoursesUsers
              .Where(t => t.CourseId == id)
              .Select(t => t.Trainer)
              .ToList();

            ViewBag.CourseId = id;

            return View(users);
        }


        /// <summary>
        /// This function is used to assign a Trainer to Course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AssignCourseTrainer(int id)
        {
            var trainer = _context.Users.OfType<Trainer>().ToList();

            var trainersInCourse = _context.CoursesUsers
              .Where(t => t.CourseId == id)
              .Select(t => t.Trainer)
              .ToList();

            var VModel = new CourseTrainersViewModel();

            if (trainersInCourse == null)
            {
                VModel.CourseId = id;
                VModel.Trainers = trainer;

                return View(VModel);
            }

            var viewModel = new CourseTrainersViewModel
            {
                CourseId = id,
                Trainers = trainer
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignCourseTrainer(CoursesUsers model)
        {
            var courseUser = new CoursesUsers
            {
                CourseId = model.CourseId,
                TrainerId = model.TrainerId
            };

            _context.CoursesUsers.Add(courseUser);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        /// <summary>
        ///  Remove Trainer from Course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RemoveTrainer(int id, string trainerId)
        {
            var trainerInCourse = _context.CoursesUsers
              .SingleOrDefault(t => t.CourseId == id && t.TrainerId == trainerId);

            if (trainerInCourse == null) return HttpNotFound();

            _context.CoursesUsers.Remove(trainerInCourse);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }
    }
}