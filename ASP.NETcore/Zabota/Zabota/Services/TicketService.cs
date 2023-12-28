using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zabota.Repositories.Interfaces;

namespace Zabota.Services
{
    public class TicketService
    {
        private IBaseRepository<Ticket> _Tickets { get; set; }
        private AppContext _appContext;
        public TicketService(IBaseRepository<Ticket> tickets, AppContext appContext)
        {
            //_Tickets = ticketsDTO.GetAll().ConvertAll(new Converter<TicketDTO, Ticket>(TicketDTOToTicket));
            _Tickets = tickets;
            _appContext = appContext;
        }
        private static Ticket TicketDTOToTicket(TicketDTO ticketDTO)
        {
            return new Ticket(ticketDTO);
        }
        public List<Ticket> GetAllTickets()
        {
            return _Tickets.GetAll();
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

        public IResult PutTicket(Ticket ticket)
        {
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
