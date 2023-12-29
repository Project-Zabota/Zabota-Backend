namespace Zabota.Dtos;

public class MessageDto
{
    public string? Sender { get; set; } //{ Client, Employee }
    public string? Text { get; set; }
    public int TicketId { get; set; }

    public MessageDto(string? sender, string? text, int ticketId)
    {
        Sender = sender;
        Text = text;
        TicketId = ticketId;
    }
}