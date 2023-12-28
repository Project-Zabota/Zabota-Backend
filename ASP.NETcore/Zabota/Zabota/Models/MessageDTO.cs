using System.Text.Json.Serialization;

public class MessageDTO
{
    public string? Sender { get; set; } //{ Client, Employee }
    public string? Text { get; set; }
    public int TicketId { get; set; }
    [JsonIgnore]
    //    [ForeignKey("TicketId")]
    public Ticket? Ticket { get; set; }
    public MessageDTO(Message message) 
    {
        Sender = message.Sender;
        Text = message.Text;
        TicketId = message.TicketId;
        Ticket = message.Ticket;
    }
}
