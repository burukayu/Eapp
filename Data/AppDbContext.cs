using Microsoft.EntityFrameworkCore;
using EntityApp.Models;

namespace EntityApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<CourseFee> CourseFees { get; set; }
        public DbSet<Course> Courses {get; set;}
        public DbSet<User> user {get; set;}
    }
}