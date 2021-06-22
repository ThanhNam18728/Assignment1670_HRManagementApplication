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
            return View(_context.Trainees.ToList());
        }
        public ActionResult ViewProfile(string id)
        {
            if (id == null) return HttpNotFound();
            var traineeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);
            return View(traineeInDb);
        }
        public ActionResult Delete(string id)
        {
            var traieeInDb = _context.Trainees.SingleOrDefault(t => t.TraineeId == id);
            if (traieeInDb == null) return HttpNotFound();
            _context.Trainees.Remove(traieeInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        

        public ActionResult ViewAssignedCourses(string id)
        {
            var courses = _context.CoursesTrainees.Where(t => t.TraineeId == id).Select(t => t.Course).ToList();

            return View(courses);
        }
    }
}