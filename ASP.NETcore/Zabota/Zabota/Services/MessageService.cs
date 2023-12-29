using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Zabota.Models;
using Zabota.Models.Enums;
using Zabota.Repositories.Interfaces;

namespace Zabota.Services
{
    public class MessageService
    {
        private IBaseRepository<Ticket> _Tickets { get; set; }
        private IBaseRepository<Message> _Messages { get; set; }
        private AppContext _appContext;
        private static readonly HttpClient _Client = new HttpClient();

        public MessageService(IBaseRepository<Ticket> ticketRepository, IBaseRepository<Message> messages, AppContext appContext)
        {
            _Tickets = ticketRepository;
            _appContext = appContext;
            _Messages = messages;
        }

        public JsonResult GetMessage(int id)
        {
            return new JsonResult(_Messages.Get(id));
        }

        public IResult GetAllMessagesByTicket(int id)
        {
            var ticket = _Tickets.Get(id);
            if (ticket != null)
            {
                return Results.Json(ticket.Messages);
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }

        public IResult PostMessage(Message message)
        {
            
            var ticket = _Tickets.Get(message.TicketId);
            if (ticket != null)
            {
                if (message.Sender.Type.Equals(SenderType.EMPOLYEE_ZABOTA))
                {
                    var response = _Client.PostAsync("http://localhost:5000/update", JsonContent.Create("{\"ticket\": " + ticket.Id + ",\"action\": \"NEW_MESSAGE\",\"data\": {\"text\": \"" + message.Text + "\"}}"));
                }
                message.Ticket = ticket;
                message.Timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                _Messages.Post(message);
                return Results.Json("ОК");
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }
    }
}
