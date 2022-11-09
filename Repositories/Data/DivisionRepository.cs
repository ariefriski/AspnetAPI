using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Model;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories.Data
{
    public class DivisionRepository : GeneralRepository<Division>
    {
        private readonly MyContext _context;

        public DivisionRepository(MyContext context):base(context)
        {
            _context = context;
        }

      
        


    }
}
