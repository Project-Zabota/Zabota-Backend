using System.ComponentModel.DataAnnotations.Schema;
using Zabota.Models;
public class Ticket
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }//{ Problem, Question, Suggestion, Feedback }
    public string? Sender { get; set; }//{ Client, Employee }
    public int Priority { get; set; }
    public virtual List<Message> Message { get; set; } = new();
}