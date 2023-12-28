using System.ComponentModel.DataAnnotations.Schema;
using Zabota.Models;
public class Ticket : BaseModel
{
//    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }//{ Problem, Question, Suggestion, Feedback }
    public string? Sender { get; set; }//{ Client, Employee }
    public int Priority { get; set; }
    public virtual List<Message>? Messages { get; set; } = new();
    public Ticket() {    }
    public Ticket(TicketDTO ticketDTO)
    {
        Name = ticketDTO.Name;
        Status = ticketDTO.Status;
        Type = ticketDTO.Type;
        Sender = ticketDTO.Sender;
        Priority = ticketDTO.Priority;
        Messages = ticketDTO.Messages;
    }
}