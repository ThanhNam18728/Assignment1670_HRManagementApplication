using System.Linq;
using System.Web.Mvc;
using HRManagement.Models;

namespace HRManagement.Controllers
{
    public class TraineesController : Controller
    {
        private ApplicationDbContext _context;
        public TraineesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Trainees
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProfile(string id)
        {            
            return View();
        }
        



        public ActionResult ViewAssignedCourses(string id)
        {
            var courses = _context.CoursesTrainees.Where(t => t.TraineeId == id).Select(t => t.Course).ToList();

            return View(courses);
        }
    }
}