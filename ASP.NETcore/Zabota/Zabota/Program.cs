using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Zabota.Dtos;
using Zabota.Mapper;
using Zabota.Models;
using Zabota.Repositories.Implimentations;
using Zabota.Repositories.Interfaces;
using Zabota.Services;

// TODO обернуть бы это всё в класс, чтобы красивеее было

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

builder.Services.AddTransient<TicketService, TicketService>();
builder.Services.AddTransient<MessageService, MessageService>();

builder.Services.AddTransient<IMapper<Sender, SenderDto>, SenderMapper>();
builder.Services.AddTransient<IMapper<Message, MessageDto>, MessageMapper>();
builder.Services.AddTransient<IMapper<Ticket, TicketDto>, TicketMapper>();
builder.Services.AddTransient<IMapper<User, UserDto>, UserMapper>();

var app = builder.Build();

app.MapGet("/", () => "ok");

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();