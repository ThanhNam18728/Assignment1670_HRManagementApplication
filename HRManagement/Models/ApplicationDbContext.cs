using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoursesTrainers> CoursesTrainers { get; set; }
        public DbSet<CoursesTrainees> CoursesTrainees { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}