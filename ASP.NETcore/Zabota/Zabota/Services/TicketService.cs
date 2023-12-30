using Zabota.Dtos;
using Zabota.Mapper;
using Zabota.Models;
using Zabota.Models.Enums;
using Zabota.Repositories.Interfaces;

namespace Zabota.Services
{
    public class TicketService
    {
        private IBaseRepository<Ticket> _Tickets { get; set; }
        private readonly IMapper<Ticket, TicketDto> ticketMapper;

        public TicketService(IBaseRepository<Ticket> tickets, IMapper<Ticket, TicketDto> ticketMapper)
        {
            _Tickets = tickets;
            this.ticketMapper = ticketMapper;
        }
        
        /**
         * Сделать чтобы в тикетах не было messages
         *
         * в теории, если не запрашивать messages, то их быть и не должно, но я не уверен
         * возможно при маппинге в dto появятся, но я не уверен
         */
        public List<Ticket> GetAllTickets()
        {
            return _Tickets.GetAll();
        }

        public int CreateTicket(TicketDto ticketDto)
        {
            ticketDto.Status = TicketStatus.CREATED;
            var ticket = ticketMapper.ToModel(ticketDto);
            
            _Tickets.Create(ticket);
            return ticket.Id;
        }

        /**
         * Не уверен, что нужен такой метод
         *
         */
        public IResult UpdateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                return Results.Json(_Tickets.Update(ticket));
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
