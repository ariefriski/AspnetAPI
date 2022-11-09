using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Base;
using WebAPI.Model;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : BaseController<DivisionRepository,Division>
    {
        private readonly DivisionRepository divisionRepo;

        public DivisionController(DivisionRepository divisionRepo):base(divisionRepo)
        {
            this.divisionRepo = divisionRepo;
        }

        //public IActionResult Get(string name)
        //{
        //    var data = divisionRepo.Get(name);
        //    return Ok(new { Message = "Get Name Success", StatusCode = 200, Data = data });
        //}



    }
}
