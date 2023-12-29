using Zabota.Models.Enums;

namespace Zabota.Dtos;

public class TicketDto 
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public TicketType? Type { get; set; }
    public Department? Department { get; set; }
    public TicketStatus? Status { get; set; }
    public SenderDto? Sender { get; set; }
    public UserDto? Worker { get; set; }
    public int? Priority { get; set; }
    public List<MessageDto>? Messages { get; set; } = new();
}