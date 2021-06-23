using System.Linq;
using System.Web.Mvc;
using HRManagement.Models;
using Microsoft.AspNet.Identity;

namespace HRManagement.Controllers
{
    public class TraineesController : Controller
    {
        private ApplicationDbContext _context;
        public TraineesController()
        {
            _context = new ApplicationDbContext();
        }
       
        public ActionResult ViewProfile(string id)
        {
            var currentTraineeId = User.Identity.GetUserId();
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == currentTraineeId);

            return View(traineeInDb);
        }
        



        public ActionResult ViewAssignedCourses()
        {
            var currentTraineeId = User.Identity.GetUserId();
            var courses = _context.CoursesTrainees.Where(t => t.TraineeId == currentTraineeId).Select(t => t.Course).ToList();

            return View(courses);
        }
    }
}