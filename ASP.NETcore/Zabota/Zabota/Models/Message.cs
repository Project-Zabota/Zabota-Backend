using System.Globalization;

namespace Zabota.Models;

public class Message : BaseModel
{
    public string Text { get; set; }
    public Sender Sender { get; set; }
    // у меня не получилось использовать тут DateTime, поэтому string
    public string Timestamp { get; set; }
    
    public int TicketId { get; set; }
    public Ticket? Ticket { get; set; }

    public Message() { }

    public Message(string text, Sender sender, DateTime timestamp, int ticketId, Ticket? ticket)
    {
        Text = text;
        Sender = sender;
        Timestamp = timestamp.ToString(CultureInfo.CurrentCulture);
        TicketId = ticketId;
        Ticket = ticket;
    }
}