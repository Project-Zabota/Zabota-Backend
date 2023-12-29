using Zabota.Dtos;
using Zabota.Models;

namespace Zabota.Mapper;

public class MessageMapper : IMapper<Message, MessageDto>
{
    private readonly IMapper<Sender, SenderDto> _senderMapper;

    public MessageMapper(IMapper<Sender, SenderDto> senderMapper)
    {
        _senderMapper = senderMapper;
    }

    public MessageDto ToDto(Message model)
    {
        var sender = _senderMapper.ToDto(model.Sender);
        return new MessageDto(model.Id, model.TicketId, model.Text, sender, DateTime.Parse(model.Timestamp));
    }

    public Message ToModel(MessageDto dto)
    {
        var sender = _senderMapper.ToModel(dto.Sender);
        return new Message(dto.Text, sender, dto.Timestamp, dto.TicketId);
    }
}