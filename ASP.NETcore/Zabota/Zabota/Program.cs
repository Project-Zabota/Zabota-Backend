using Microsoft.EntityFrameworkCore;
using Zabota.Models;
using Zabota.Repositories.Interfaces;
using Zabota.Repositories.Implimentations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddDbContext<AppContext>(options => options.UseNpgsql(connection));
builder.Services.AddControllers();
builder.Services.AddTransient<IBaseRepository<Ticket>, BaseRepository<Ticket>>();
builder.Services.AddTransient<IBaseRepository<Message>, BaseRepository<Message>>();
builder.Services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();



var app = builder.Build();

app.MapGet("/", () => "ok");

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
