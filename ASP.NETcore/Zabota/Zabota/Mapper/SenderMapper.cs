using Zabota.Dtos;
using Zabota.Models;

namespace Zabota.Mapper;

public class SenderMapper : IMapper<Sender, SenderDto>
{
    private readonly IMapper<User, UserDto> _userMapper;

    public SenderMapper(IMapper<User, UserDto> userMapper)
    {
        _userMapper = userMapper;
    }

    public SenderDto ToDto(Sender model)
    {
        return new SenderDto(model.Name, model.Type);
    }

    public Sender ToModel(SenderDto dto)
    {
        var user = dto.User == null
            ? null
            : _userMapper.ToModel(dto.User);
        
        return new Sender(dto.Name, dto.Type, user);
    }
}