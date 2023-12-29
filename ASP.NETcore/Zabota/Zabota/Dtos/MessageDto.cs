namespace Zabota.Dtos;

public class MessageDto
{
    public int? Id { get; set; }
    public int TicketId { get; set; }
    public string? Text { get; set; }
    public SenderDto? Sender { get; set; }
    public DateTime Timestamp { get; set; }

    public MessageDto()
    {
    }

    public MessageDto(int? id, int ticketId, string? text, SenderDto? sender, DateTime timestamp)
    {
        Id = id;
        TicketId = ticketId;
        Text = text;
        Sender = sender;
        Timestamp = timestamp;
    }
}