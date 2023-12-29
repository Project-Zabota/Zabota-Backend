using Zabota.Repositories.Interfaces;
using Zabota.Models;

namespace Zabota.Services
{
    public class UserService
    {
        private IBaseRepository<User> _Users { get; set; }

        public UserService(IBaseRepository<User> Users)
        {
            _Users = Users;
        }

        public List<User> GetAllUsers()
        {
            return _Users.GetAll();
        }

        public User GetById(int id)
        {
            return _Users.Get(id);
        }

        public int PostUser(User user)
        {
            _Users.Post(user);
            return user.Id;
        }

        public IResult DeleteUser(int id)
        {
            var user = _Users.Get(id);
            if (user != null)
            {
                _Users.Delete(id);
                return Results.Json(new { message = "Заявка успешно удалена" });
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }
    }
}
