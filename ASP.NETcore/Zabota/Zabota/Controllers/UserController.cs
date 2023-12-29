using Microsoft.AspNetCore.Mvc;
using Zabota.Models;
using Zabota.Repositories.Interfaces;
using Zabota.Services;


namespace Zabota.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController
    {
        private UserService _userService { get; set; }
    }
}
