using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Base;
using WebAPI.Model;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentRepository, Department>
    {
        private readonly DepartmentRepository departmentRepo;

        public DepartmentController(DepartmentRepository departmentRepo):base(departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        [HttpGet("Email")]
       public ActionResult DepartmentName(string department)
        {
            var data = departmentRepo.DepartmentName(department);
            return Ok(data);
        }

        //[Authorize]
        //[HttpGet]
        //public ActionResult Get()
        //{
        //    var data = departmentRepo.Get();
        //    try
        //    {
        //        if (data == null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil diupdate"

        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                Status = 200,
        //                Message = "Data gagal  diupdate",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message
        //        });
        //    }
        //}


        //[Authorize]
        //[HttpGet("{id}")]
        //public ActionResult GetById(int id)
        //{
        //    var data = departmentRepo.Get(id);
        //    try
        //    {
        //        if (data == null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil diupdate"

        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                Status = 200,
        //                Message = "Data gagal  diupdate",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message
        //        });
        //    }
        //}

        //[Authorize]
        //[HttpPost]
        //public ActionResult Create(Department department)
        //{
        //    var data = departmentRepo.Create(department);
        //    try
        //    {
        //        if (data == null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil diupdate"

        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                Status = 200,
        //                Message = "Data gagal  diupdate",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message
        //        });
        //    }
        //}

        //[Authorize]
        //[HttpPut]
        //public ActionResult Update(Department department)
        //{
        //    var data = departmentRepo.Update(department);
        //    try
        //    {
        //        if (data == null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil diupdate"

        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                Status = 200,
        //                Message = "Data gagal  diupdate",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message
        //        });
        //    }
        //}
        //[Authorize]
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    var data = departmentRepo.Delete(id);
        //    try
        //    {
        //        if (data == null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil diupdate"

        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                Status = 200,
        //                Message = "Data gagal  diupdate",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message
        //        });
        //    }
        //}
    }

    // var data = context.Departments.Include(x=>x.employee.)
}
