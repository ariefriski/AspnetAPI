using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly DivisionRepository divisionRepo;

        public DivisionController(DivisionRepository divisionRepo)
        {
            this.divisionRepo = divisionRepo;
        }


        [HttpGet]
        public ActionResult GetList()
        {
            var data = divisionRepo.Get();
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ditemukan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil ditemukan",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400m,
                    Message = ex.Message
                });
            }   
            
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var data = divisionRepo.GetById(id);

            try {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ada"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data ada",
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
        public ActionResult Create(Division division)
        {
            var data = divisionRepo.Create(division);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data gagal disimpan"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data Berhasil disimpah",
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
        public ActionResult Update(Division division)
        {
            var data = divisionRepo.Update(division);
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
            var data = divisionRepo.Delete(id);
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
}
