using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Model;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories
{

    public class EmployeeRepository : IRepository<Employee, int>
    {
        private readonly MyContext _context;

        public EmployeeRepository(MyContext context)
        {
            _context = context;
        }

        public int Create(Employee entity)
        {
            _context.Employees.Add(entity);
            var data = _context.SaveChanges();
            return data;
        }

        public int Delete(int id)
        {
            var data = _context.Employees.Find(id);
            if (data != null){
                _context.Employees.Remove(data);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public ICollection<Employee> Get()
        {
                return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public int Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var data = _context.SaveChanges();
            return data;
        }

        


    }
}
