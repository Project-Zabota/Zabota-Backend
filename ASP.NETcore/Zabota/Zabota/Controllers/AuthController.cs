using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zabota.Models;
using Zabota.Repositories.Interfaces;
using Zabota.Services;

namespace Zabota.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserService _userService {  get; set; }

        public AuthController(IBaseRepository<User> users) 
        {
            _userService = new UserService(users);
        }

        [Route("login")]
        [HttpPost]
        public string GetJWT(User user)
        {
            return _userService.GetJWTByUser(user);
        }

        [Route("data")]
        [Authorize]
        public string smth()
        {
            return "Hello world";
        }
    }
}
