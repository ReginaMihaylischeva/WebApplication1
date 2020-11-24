using Microsoft.EntityFrameworkCore;
using TestsTesk.Models.Response;

namespace TestsTesk.Context
{
    //class MyContextInitializer : DropCreateDatabaseAlways<PublicDbContext>
    //{
    //    protected override void Seed(PublicDbContext db)
    //    {
    //        Group p1 = new Group { Name = "Тест1"};
    //        Group p2 = new Group { Name = "Тест2" };

    //        db.Groups.Add(p1);
    //        db.Groups.Add(p2);
    //        db.SaveChanges();
    //    }
    //}
    public class PublicDbContext : DbContext
    {
        public PublicDbContext(DbContextOptions<PublicDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public DbSet<TestsTesk.Models.Response.GroupResponse> GroupResponse { get; set; }
    }
}