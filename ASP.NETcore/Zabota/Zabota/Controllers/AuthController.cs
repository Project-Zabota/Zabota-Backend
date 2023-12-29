using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Zabota.Repositories.Interfaces;
using Zabota.Services;
using Zabota.Models;

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
