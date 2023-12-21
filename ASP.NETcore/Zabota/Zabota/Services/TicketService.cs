using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zabota.Repositories.Interfaces;

namespace Zabota.Services
{
    public class TicketService
    {
        private IBaseRepository<Ticket> _Tickets { get; set; }
        private AppContext _appContext;
        public TicketService(IBaseRepository<Ticket> ticketRepository, AppContext appContext)
        {
            _Tickets = ticketRepository;
            _appContext = appContext;
        }
        public JsonResult GetAllTickets()
        {
            return new JsonResult(_Tickets.GetAll());
        }

        public JsonResult GetTicket(int id)
        {
            return new JsonResult(_appContext.Tickets.Include(m => m.Messages).Where(m => m.Id == id).First());
        }

        public JsonResult PostTicket(Ticket ticket)
        {
            _Tickets.Post(ticket);
            return new JsonResult(ticket.Id);
        }

        public IResult PutTicket(Ticket ticketData)
        {
            var ticket = _Tickets.Get(ticketData.Id);
            if (ticket != null)
            {
                return Results.Json(_Tickets.Put(ticket));
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }

        public IResult DeleteTicket(int id)
        {
            var ticket = _Tickets.Get(id);
            if (ticket != null)
            {
                _Tickets.Delete(id);
                return Results.Json(new { message = "Заявка успешно удалена" });
            }
            return Results.NotFound(new { message = "Заявка не найдена" });
        }
    }
}
