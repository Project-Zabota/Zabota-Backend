using Zabota.Models;
public class TicketDTO : BaseModel
{
    public string? Name { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }//{ Problem, Question, Suggestion, Feedback }
    public string? Sender { get; set; }//{ Client, Employee }
    public int Priority { get; set; }
    public virtual List<Message>? Messages { get; set; } = new();

    public TicketDTO(Ticket ticket)
    {
        Name = ticket.Name;
        Status = ticket.Status;
        Type = ticket.Type;
        Sender = ticket.Sender;
        Priority = ticket.Priority;
        Messages = ticket.Messages;
    }
}
