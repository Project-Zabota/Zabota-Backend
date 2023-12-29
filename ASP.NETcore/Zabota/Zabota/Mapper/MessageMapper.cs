using Zabota.Dtos;
using Zabota.Models;

namespace Zabota.Mapper;

public class MessageMapper : IMapper<Message, MessageDto>
{
    public MessageDto ToDto(Message model)
    {
        return new MessageDto();
    }

    public Message ToModel(MessageDto model)
    {
        throw new NotImplementedException();
    }
}