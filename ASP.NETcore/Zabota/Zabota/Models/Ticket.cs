using Zabota.Models.Enums;

namespace Zabota.Models;

public class Ticket : BaseModel
{
    public string Name { get; set; }
    public string Webhook {  get; set; }
    public TicketType Type { get; set; }
    
    public Department Department { get; set; }
    public TicketStatus Status { get; set; }
    public Sender Sender { get; set; }
    
    public User? Worker { get; set; }
    public int Priority { get; set; }
    public virtual List<Message>? Messages { get; set; } = new();
}