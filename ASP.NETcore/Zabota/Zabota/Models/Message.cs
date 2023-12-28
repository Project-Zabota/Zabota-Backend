using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Zabota.Models;
public class Message : BaseModel
{
    public string? Sender { get; set; } //{ Client, Employee }
    public string? Text { get; set; }
    public string? Timestamp { get; set; }
    public int TicketId { get; set; }
    [JsonIgnore]
//    [ForeignKey("TicketId")]
    public Ticket? Ticket { get; set; }
    //public Message(MessageDTO messageDTO)
    //{
    //    Sender = messageDTO.Sender;
    //    Text = messageDTO.Text;
    //    TicketId = messageDTO.TicketId;
    //    Ticket = messageDTO.Ticket;
    //    Timestamp = DateTime.Now.ToString();
    //}
}

