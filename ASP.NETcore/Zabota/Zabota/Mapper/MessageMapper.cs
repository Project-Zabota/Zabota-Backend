using Zabota.Dtos;
using Zabota.Models;

namespace Zabota.Mapper;

public class MessageMapper : IMapper<Message, MessageDto>
{
    public MessageDto ToDto(Message model)
    {
        throw new NotImplementedException();
    }

    public Message ToModel(MessageDto model)
    {
        throw new NotImplementedException();
    }
}