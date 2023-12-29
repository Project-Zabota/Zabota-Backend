using Microsoft.AspNetCore.Mvc;
using Zabota.Models;
using Zabota.Repositories.Interfaces;
using Zabota.Services;

namespace Zabota.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController
    {
        private UserService _userService {  get; set; }

        public AuthController(IBaseRepository<User> users) 
        {
            _userService = new UserService(users);
        }


    }
}
