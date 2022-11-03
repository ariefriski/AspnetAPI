using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Model;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories
{
    public class DepartmentRepository:IRepository<Department,int>
    {
        MyContext _context;

        public DepartmentRepository(MyContext context)
        {
            _context = context;
        }

        public int Create(Department entity)
        {
            _context.Departments.Add(entity);
            var save = _context.SaveChanges();
            return save;
        }

        public int Delete(int id)
        {
            var delete  = _context.Departments.Find(id);
            if(delete != null)
            {
                _context.Remove(delete);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public ICollection<Department> Get()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public int Update(Department entity)
        {
            _context.Entry(entity).State= EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}
