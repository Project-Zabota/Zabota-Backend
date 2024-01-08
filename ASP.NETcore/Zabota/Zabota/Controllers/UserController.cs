using Microsoft.AspNetCore.Mvc;
using Zabota.Dtos;
using Zabota.Models;
using Zabota.Repositories.Interfaces;
using Zabota.Services;


namespace Zabota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService { get; set; }

        public UserController(UserService user)
        {
            _userService = user;
        }

        [HttpPost]
        [Route("save")]
        public int SaveUser(User user)
        {
            return _userService.SaveUser(user);
        }

        [Route("all")]
        [HttpGet]
        public List<UserDto> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [Route("{id:int}")]
        [HttpGet]
        public UserDto GetUser(int id)
        {
            var a = _userService.GetById(id);
            return _userService.GetById(id);
        }

        [Route("Delete")]
        [HttpDelete]
        public string DeleteUser(int id)
        {
            return _userService.DeleteUser(id).ToString();
        }
    }
}
