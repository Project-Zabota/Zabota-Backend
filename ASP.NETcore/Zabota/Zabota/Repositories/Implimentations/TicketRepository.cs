using Microsoft.EntityFrameworkCore;
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
                .Where(t => t.Worker.Department == user.Department && 
                            (t.Worker.Id == userId && 
                                t.Status == TicketStatus.IN_WORK || t.Status == TicketStatus.CLOSED
                            || t.Status == TicketStatus.CREATED))
                .ToList();
        }

        public Ticket GetTicketWithMessages(int ticketId)
        {
            return Context.Tickets.Include(t => t.Messages).ThenInclude(t => t.Sender).First(t => t.Id == ticketId);
        }
    }
}
