using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Repositories.Interface;

namespace WebAPI.Base
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository,Entity> : ControllerBase
        where Repository : class, IRepository<Entity,int>
        where Entity : class
    {
        Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = repository.Get();
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Failed Get Data"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Success Get Data",
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
        public IActionResult Get(int id)
        {
            var data = repository.Get(id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Error Get Id"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data successfully get by id",
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
        public IActionResult Create(Entity entity)
        {
            var data = repository.Create(entity);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Error Create Data"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data successfully Created",
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
        public IActionResult Update(Entity entity)
        {
            var data = repository.Update(entity);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Error Update data"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data successfully Updatet",
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
        public IActionResult Delete(int id)
        {
            var data = repository.Delete(id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Error Deleted Data"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = 200,
                        Message = "Data successfully Deleted",
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
