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
    }
}
