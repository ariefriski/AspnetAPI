using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Base;
using WebAPI.Model;
using WebAPI.Repositories.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Staff,Programmer")]
    public class UserController : BaseController<UserRepository,User>
    {
        private readonly UserRepository userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;
        public UserController(UserRepository userRepository,IConfiguration configuration, ILogger<UserController> logger):base(userRepository)
        {
            this.userRepository = userRepository;
            _configuration = configuration;
            _logger = logger;   
        }

        

        [AllowAnonymous]
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
                        Message = "Error Email Sudah Terdaftar!"
                    });
                }
                else
                {
                   // string token = CreateToken(email);
                    return Ok(new
                    {
                        Message = "Register Berhasil",
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

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(string email, string password)
        {
            var data = userRepository.Login(email,password);
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
                    var claims = new[]
                    {
                        new Claim("Fullname",data.FullName),
                        new Claim("role",data.Role)
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

                    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                         _configuration["Jwt:Issuer"],
                         _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: cred
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                //new
                //{
                //    StatusCode = 200,
                //    Message = "Login berhasil!",
                //    Data = new
                //    {
                //        data.employee.Fullname,
                //        data.employee.Email,
                //        data.role.Name
                //    }
                //}
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

        //private string CreateToken(string email)
        //{
            
        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Email,email),

        //    };

        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

        //    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //         _configuration["Jwt:Issuer"],
        //         _configuration["Jwt:Audience"],
        //        claims: claims,
        //        expires: DateTime.Now.AddDays(1),
        //        signingCredentials: cred
        //        );

        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;
        //}

        [Authorize]
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

        [Authorize]
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
