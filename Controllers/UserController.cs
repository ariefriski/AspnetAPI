using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var data = userRepository.Get();
            try
            {
                if(data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak ada "
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil di Get",
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
            var data = userRepository.GetById(id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak ada "
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil di Get",
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
        public ActionResult Create(User user)
        {
            var data = userRepository.Create(user);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal dibuat"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil dibuat",
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
        public ActionResult Update(User user)
        {
            var data = userRepository.Update(user);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal di Update"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil diUpdate",
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
            var data = userRepository.Delete(id);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Dihapus"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Dihapus",
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


 
        [HttpPost("Register")]
        public ActionResult Register(string fullname, string email, string birthdate, string password)
        {
            var data = userRepository.Register(fullname, email, birthdate, password);

            try
            {
               if(data == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Email sudah ada !"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil",
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


        [HttpPost("Login")]
        public ActionResult Login(string email, string password)
        {
            var data = userRepository.Login(email, password);
            try
            {
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login gagal",
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login berhasil!",
                        Data = data.employee.Fullname,
                        data.employee.Email,
                        data.role.Name
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

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(string OldPassword, string password, string email)
        {

            var data = userRepository.ChangePassword(OldPassword, password, email);
            try
            {
                if (data == 0)
                {
                    return Ok(new { Message = "error" });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Sukses",
                        Data = data
                    });
                }
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }


        [HttpPut("ResetPassword")]
        public ActionResult ResetPassword(string fullName, string email, string birthDate, string newPassword)
        {
            var data = userRepository.ResetPassword(fullName, email, birthDate, newPassword);
            try
            {
                if (data == 0)
                {
                    return Ok(new { Message = "error" });
                }
                else
                {
                    return Ok(new
                    {
                        Message = "Sukses",
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
