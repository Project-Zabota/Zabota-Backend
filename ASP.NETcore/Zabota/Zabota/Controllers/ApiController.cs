using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Zabota.Repositories.Interfaces;
using Zabota.Services;

namespace Zabota.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private TicketService _TicketService { get; set; }
        private MessageService _MessageService { get; set; }

        public ApiController(IBaseRepository<Ticket> tickets, IBaseRepository<Message> messages, AppContext appContext)
        {
            _TicketService = new TicketService(tickets, appContext);
            _MessageService = new MessageService(tickets, messages, appContext);
        }

        [Route("ticket")]
        [HttpGet]
        public JsonResult GetAllTickets()
        {
            return _TicketService.GetAllTickets();
        }

        [Route("ticket/{id:int}")]
        [HttpGet]
        public JsonResult GetTicket(int id)
        {
            return _TicketService.GetTicket(id);
        }

        [Route("ticket")]
        [HttpPost]
        public JsonResult PostTicket(Ticket ticket)
        {
            return _TicketService.PostTicket(ticket);
        }

        [Route("ticket")]
        [HttpPut]
        public IResult PutTicket(Ticket ticketData)
        {
            return _TicketService.PutTicket(ticketData);
        }

        [Route("ticket/{id:int}")]
        [HttpDelete]
        public IResult DeleteTicket(int id)
        {
            return _TicketService.DeleteTicket(id);
        }

        [Route("ticket/message/{id:int}")]
        [HttpGet]
        public JsonResult GetMessage(int id)
        {
            return _MessageService.GetMessage(id);
        }

        [Route("ticket/{id:int}/message")]
        [HttpGet]
        public IResult GetAllMessagesByTicket(int id)
        {
            return _MessageService.GetAllMessagesByTicket(id);
        }

        [Route("ticket/message")]
        [HttpPost]
        public IResult PostMessage(Message message)
        {
            return _MessageService.PostMessage(message);
        }
    }
}
