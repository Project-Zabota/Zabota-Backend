using Microsoft.EntityFrameworkCore;
using Zabota.Models;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppContext>(options => options.UseNpgsql(connection));
builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/", (AppContext db) => 
 
    db.Tickets.Include(m => m.Message).ToList()
);

app.MapGet("/api/ticket", async (AppContext db) => await db.Tickets.ToListAsync());

app.MapGet("/api/ticket/{id:int}", async (int id, AppContext db) =>
{
    Ticket? ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == id);

    if (ticket == null) return Results.NotFound(new { message = "���������� �� ������" });

    return Results.Json(ticket);
});

app.MapPost("/api/ticket", async (Ticket ticket, AppContext db) =>
{
    await db.Tickets.AddAsync(ticket);
    await db.SaveChangesAsync();
    return ticket;
});

app.MapPut("/api/ticket", async (Ticket ticketData, AppContext db) =>
{
    var ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == ticketData.Id);

    if (ticket == null) return Results.NotFound(new { message = "������ �� �������" });

    ticket.Name = ticketData.Name;
    ticket.Status = ticketData.Status;
    ticket.Type = ticketData.Type;
    ticket.Sender = ticketData.Sender;
    ticket.Priority = ticketData.Priority;
    await db.SaveChangesAsync();
    return Results.Json(ticket);
});


app.MapDelete("/api/ticket/{id:int}", async (int id, AppContext db) =>
{
    Ticket? ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == id);

    if (ticket == null) return Results.NotFound(new { message = "������ �� �������" });

    db.Tickets.Remove(ticket);
    await db.SaveChangesAsync();
    return Results.Json(ticket);
});

app.MapGet("/api/message/{id:int}", async (int id, AppContext db) =>
{
    var message = await db.Messages.FirstOrDefaultAsync(x => x.Id == id);

    if (message == null) return Results.NotFound(new { message = "��������� �� �������" });

    return Results.Json(message);
});

app.MapGet("/api/ticket/{id:int}/message/", async (int id, AppContext db) =>
{
    var ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == id);

    if (ticket.Message == null) return Results.NotFound(new { message = "��������� � ������ ������ �� �������"});

    return Results.Json(db.Tickets.Include(m => m.Message).ToList());
});

app.MapPost("/api/ticket/{id:int}/message", async (int id, Message message, AppContext db) =>
{
    var ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == id);

    if (ticket == null) return Results.NotFound(new { message = "������ �� �������" });

    message.Ticket = ticket;
    db.Messages.Add(message);
    db.SaveChanges();

    return Results.Json(db.Tickets.Include(m => m.Message).ToList());
});

//app.MapPut("/api/ticket/message/{id:int}", async (int id, Message message, AppContext db) =>
//{
//    var ticket = await db.Tickets.FirstOrDefaultAsync(x => x.Id == id);

//    if (ticket == null) return Results.NotFound(new { message = "������ �� �������" });


//});

app.Run();
