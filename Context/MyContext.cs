using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
