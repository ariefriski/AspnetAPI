using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepository departmentRepo;

        public DepartmentController(DepartmentRepository departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = departmentRepo.Get();
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil diupdate"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data gagal  diupdate",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = departmentRepo.GetById(id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil diupdate"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data gagal  diupdate",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            var data = departmentRepo.Create(department);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil diupdate"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data gagal  diupdate",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public ActionResult Update(Department department)
        {
            var data = departmentRepo.Update(department);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil diupdate"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data gagal  diupdate",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = departmentRepo.Delete(id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil diupdate"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data gagal  diupdate",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }

    // var data = context.Departments.Include(x=>x.employee.)
}
