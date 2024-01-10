using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zabota.Dtos;
using Zabota.Services;

namespace Zabota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserService _userService {  get; set; }

        public AuthController(UserService user) 
        {
            _userService = user;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult  GetJWT(UserDto user)
        {
            try
            {
                return Ok(_userService.GetJWTByUser(user));
            }
            catch(ArgumentException e)
            {
                return BadRequest();
            }
        }

        [Route("data")]
        [Authorize]
        public string smth()
        {
            return "Hello world";
        }
    }
}
