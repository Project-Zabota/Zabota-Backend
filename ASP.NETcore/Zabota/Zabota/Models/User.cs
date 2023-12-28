namespace Zabota.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}