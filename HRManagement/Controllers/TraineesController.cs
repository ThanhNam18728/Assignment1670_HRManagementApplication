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
            return View(_context.Users.OfType<Trainee>().ToList());
        }
        public ActionResult ViewProfile(string id)
        {
            if (id == null) return HttpNotFound();
            var traineeInDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == id);
            return View(traineeInDb);
        }
        public ActionResult Delete(string id)
        {
            var traieeInDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == id);
            if (traieeInDb == null) return HttpNotFound();
            _context.Users.Remove(traieeInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            var traineeInDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == id);
            if (traineeInDb == null) return HttpNotFound();
            return View(traineeInDb);
        }

        [HttpPost]
        public ActionResult Update(Trainee trainee)
        {
            var traineeInDb = _context.Users.OfType<Trainee>().SingleOrDefault(t => t.Id == trainee.Id);
            {
                traineeInDb.FullName = trainee.FullName;
                traineeInDb.DateOfBirth = trainee.DateOfBirth;
                traineeInDb.Department = trainee.Department;
                traineeInDb.Education = trainee.Education;
                traineeInDb.ProgrammingLanguage = trainee.ProgrammingLanguage;
                traineeInDb.ToeicScore = trainee.ToeicScore;
                traineeInDb.Experience = trainee.Experience;
                traineeInDb.Location = trainee.Location;
            }

            _context.SaveChanges();

            return RedirectToAction ("Index");
        }

        public ActionResult ViewAssignedCourses(string id)
        {
            var courses = _context.CoursesTrainees.Where(t => t.TraineeId == id).Select(t => t.Course).ToList();

            return View(courses);
        }
    }
}