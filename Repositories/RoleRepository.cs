using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Model;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories
{
    public class RoleRepository : IRepository<Role, int>
    {
        private readonly MyContext _context;
        public RoleRepository(MyContext context)
        {
            _context = context;
        }

        public int Create(Role entity)
        {
            _context.Roles.Add(entity);
            var data = _context.SaveChanges();
            return data;
        }

        public int Delete(int id)
        {
            var data = _context.Roles.Find(id);
            if(data != null)
            {
                _context.Remove(data);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;

        }

        public ICollection<Role> Get()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(id);
        }

        public int Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var data = _context.SaveChanges();
            return data;
        }
    }
}
