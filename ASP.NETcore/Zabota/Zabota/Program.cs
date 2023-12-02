using Microsoft.EntityFrameworkCore;
using Zabota.Models;
using Zabota.Repositories.Interfaces;
using Zabota.Repositories.Implimentations;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppContext>(options => options.UseNpgsql(connection));
builder.Services.AddControllers();
builder.Services.AddTransient<IBaseRepository<Ticket>, BaseRepository<Ticket>>();
builder.Services.AddTransient<IBaseRepository<Message>, BaseRepository<Message>>();

var app = builder.Build();

app.MapGet("/", () => "ok");

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
