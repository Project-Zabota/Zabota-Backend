using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zabota.Repositories.Interfaces;

namespace Zabota.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IBaseRepository<Ticket> Tickets { get; set; }
        private IBaseRepository<Message> Messages{ get; set; }
        private AppContext _appContext;
        private static readonly HttpClient client = new HttpClient();

        public ApiController(IBaseRepository<Ticket> Ticket, IBaseRepository<Message> messages, AppContext appContext)
        {
            Tickets = Ticket;
            Messages = messages;
            _appContext = appContext;
        }

        [Route("ticket")]
        [HttpGet]
        public JsonResult GetAllTickets()
        {
            return new JsonResult(Tickets.GetAll());
        }

        [Route("ticket/{id:int}")]
        [HttpGet]
        public JsonResult GetTicket(int id)
        {
            return new JsonResult(Tickets.Get(id));
        }

        [Route("ticket")]
        [HttpPost]
        public JsonResult PostTicket(Ticket ticket)
        {
            Tickets.Post(ticket);
            return new JsonResult(ticket.Id);
        }

        [Route("ticket")]
        [HttpPut]
        public IResult PutTicket(Ticket ticketData)
        {
            var ticket = Tickets.Get(ticketData.Id);
            if (ticket != null)
            {
                return Results.Json(Tickets.Put(ticket));
            }
            return Results.NotFound(new {message = "Заявка не найдена"});
        }

        [Route("ticket")]
        [HttpDelete]
        public IResult DeleteTicket(int id)
        {
            var ticket = Tickets.Get(id);
            if (ticket != null)
            {
                Tickets.Delete(id);
                return Results.Json(new { message = "Заявка успешно удалена" });
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }

        [Route("ticket/message/{id:int}")]
        [HttpGet]
        public JsonResult GetMessage(int id)
        {
            return new JsonResult(Messages.Get(id));
        }

        [Route("ticket/{id:int}/message")]
        [HttpGet]
        public IResult GetAllMessagesByTicket(int id)
        {
            var ticket = Tickets.Get(id);
            if (ticket != null)
            {
                return Results.Json(_appContext.Tickets.Include(m => m.Messages).Where(m => m.Id == id).First());
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }

        [Route("ticket/message")]
        [HttpPost]
        public IResult PostMessage(Message message)
        {
            
            var ticket = Tickets.Get(message.TicketId);
            if (ticket != null)
            {
                var response = client.PostAsync("http://localhost:5000/update", JsonContent.Create("{ticket: " + ticket.Id + ",action: “NEW_MESSAGE”,data: {text: " + message.Text + "}}"));
                message.Ticket = ticket;
                Messages.Post(message);
                return Results.Json("ОК");
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }
    }
}
