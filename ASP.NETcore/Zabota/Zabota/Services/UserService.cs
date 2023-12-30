using Zabota.Models;
using Zabota.Repositories.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

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

        public string GetJWTByUser(User userData)
        {
            var user = _Users.GetAll().FirstOrDefault(p => p.Email == userData.Email && GetHash(p.Password) == userData.Password);
            if (user == null) { return Results.Unauthorized().ToString(); }
            var claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Email, user.Email), 
                new Claim(ClaimTypes.Name, user.FirstName), 
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim("MiddleName", user.MiddleName)
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public int SaveUser(User user)
        {
            user.Password = GetHash(user.Password);
            _Users.Post(user);
            return user.Id;
        }

        private string GetHash(string password)
        {
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
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
