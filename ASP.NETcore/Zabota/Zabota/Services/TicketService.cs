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
        private IBaseRepository<User> _Users { get; set; }
        private readonly IMapper<Ticket, TicketDto> ticketMapper;
        private readonly IMapper<User, UserDto> userMapper;

        public TicketService(IBaseRepository<Ticket> tickets, IBaseRepository<User> users, IMapper<Ticket, TicketDto> ticketMapper, IMapper<User, UserDto> userMapper)
        {
            _Tickets = tickets;
            _Users = users;
            this.ticketMapper = ticketMapper;
            this.userMapper = userMapper;
        }
        
        /**
         * Сделать чтобы в тикетах не было messages
         *
         * в теории, если не запрашивать messages, то их быть и не должно, но я не уверен
         * возможно при маппинге в dto появятся, но я не уверен
         */
        public List<TicketDto> GetAllTickets()
        {
            return _Tickets.GetAll().ToList().Select(t => ticketMapper.ToDto(t)).ToList();
        }

        public TicketDto GetTicketById(int id) 
        {
            return ticketMapper.ToDto(_Tickets.Get(id));
        }

        public int CreateTicket(TicketDto ticketDto)
        {
            ticketDto.Status = TicketStatus.CREATED;
            var ticket = ticketMapper.ToModel(ticketDto);
            
            _Tickets.Create(ticket);
            return ticket.Id;
        }

        public void ChangeTicketStatus(int id, TicketStatus status) 
        {
            var ticket = _Tickets.Get(id);
            ticket.Status = status;
            _Tickets.Update(ticket);
        }

        public void ChangeTicketDepartment(int id, Department department)
        {
            var ticket = _Tickets.Get(id);
            ticket.Department = department;
            ticket.Worker = null;
            _Tickets.Update(ticket);
        }

        public void ChangeTicketUser(int ticketId, int userId)
        {
            var ticket = _Tickets.Get(ticketId);
            var user = _Users.Get(userId);
            ticket.Worker = user;
            _Tickets.Update(ticket);
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
