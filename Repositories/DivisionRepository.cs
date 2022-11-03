using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Model;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories
{
    public class DivisionRepository : IRepository<Division,int>
    {
        private readonly MyContext _context;

        public DivisionRepository(MyContext context)
        {
            _context = context;
        }
        public int Create(Division entity)
        {
            _context.Divisions.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var delete = _context.Divisions.Find(id); 
            if (delete != null)
            {
                _context.Remove(delete);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public ICollection<Division> Get()
        {
            return _context.Divisions.ToList();
        }

        public Division GetById(int id)
        {
            return _context.Divisions.Find(id);
        }

        public int Update(Division entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }


        //[HttpGet]
        //public IEnumerable<Division> GetList()
        //{
        //    return _context.Divisions.ToList();
        //}
        //[HttpGet("{id}")]
        //public Division GetById(int id)
        //{
        //    return _context.Divisions.Find(id);

        //}
        //[HttpPost]
        //public int Create(Division division)
        //{
        //    _context.Divisions.Add(division);
        //    var result =  _context.SaveChanges();
        //    return result;
        //}
        //[HttpPut]
        //public int Update(Division division)
        //{
        //    _context.Entry(division).State = EntityState.Modified;
        //    var result = _context.SaveChanges();
        //    return result;
        //}

        //[HttpDelete]
        //public int Delete (int id)
        //{
        //    var delete =  _context.Divisions.Find(id);
        //    _context.Divisions.Remove(delete);
        //    if (delete != null)
        //    {
        //        _context.Remove(delete);
        //        var result = _context.SaveChanges();
        //        return result;
        //    }
        //    return 0;
        //}


    }
}
