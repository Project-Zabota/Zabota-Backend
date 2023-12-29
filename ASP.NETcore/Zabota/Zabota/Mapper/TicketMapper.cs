using Zabota.Dtos;
using Zabota.Models;

namespace Zabota.Mapper;

public class TicketMapper : IMapper<Ticket, TicketDto>
{
    private readonly IMapper<Message, MessageDto> _messageMapper;
    private readonly IMapper<User, UserDto> _userMapper;
    private readonly IMapper<Sender, SenderDto> _senderMapper;

    public TicketMapper(IMapper<Message, MessageDto> messageMapper, IMapper<User, UserDto> userMapper, IMapper<Sender, SenderDto> senderMapper)
    {
        _messageMapper = messageMapper;
        _userMapper = userMapper;
        _senderMapper = senderMapper;
    }

    public TicketDto ToDto(Ticket model)
    {
        var messages = new List<MessageDto>(); 
        if (model.Messages != null)
            messages = model.Messages.Select(m => _messageMapper.ToDto(m)).ToList();

        UserDto? worker = null;
        if (model.Worker != null)
            worker = _userMapper.ToDto(model.Worker);
        
        return new TicketDto
        {
            Id = model.Id,
            Name = model.Name,
            Type = model.Type,
            Department = model.Department,
            Status = model.Status,
            Worker = worker,
            Priority = model.Priority,
            Messages = messages
        };
    }

    public Ticket ToModel(TicketDto dto)
    {
        Sender sender = _senderMapper.ToModel(dto.Sender);

        return new Ticket
        {
            Name = dto.Name,
            Type = dto.Type,
            Department = dto.Department,
            Status = dto.Status,
            Sender = sender,
            Worker = null,
            Priority = dto.Priority,
        };
    }
}