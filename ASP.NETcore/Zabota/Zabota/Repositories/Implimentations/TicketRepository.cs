using Microsoft.EntityFrameworkCore;
using Zabota.Dtos;
using Zabota.Mapper;
using Zabota.Models;
using Zabota.Models.Enums;

namespace Zabota.Repositories.Implimentations
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        private AppContext Context { get; set; }
        public TicketRepository(AppContext context) : base(context)
        {
            Context = context;
        }

        public List<Ticket> GetTicketsFromUser(int userId)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == userId);
            return Context.Tickets.Include(t => t.Worker)
                .Where(u => u.Worker.Id == userId)
                .Where(t => (t.Status == TicketStatus.IN_WORK && t.Worker.Department == user.Department) || t.Status == TicketStatus.CREATED || t.Status == TicketStatus.CLOSED)
                .ToList();
        }

        public Ticket GetTicketWithMessages(int ticketId)
        {
            return Context.Tickets.Include(t => t.Messages).ThenInclude(t => t.Sender).First(t => t.Id == ticketId);
        }
    }
}
