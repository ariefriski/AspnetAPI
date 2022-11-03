using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
