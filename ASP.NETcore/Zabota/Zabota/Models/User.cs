namespace Zabota.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string userName, string login, string email, string password)
        {
            UserName = userName;
            Login = login;
            Email = email;
            Password = password;
        }
    }
}