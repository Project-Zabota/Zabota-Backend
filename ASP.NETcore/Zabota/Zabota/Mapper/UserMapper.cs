using Zabota.Dtos;
using Zabota.Models;

namespace Zabota.Mapper;

public class UserMapper : IMapper<User, UserDto>
{
    public UserDto ToDto(User model)
    {
        return new UserDto(model.Id, model.FirstName, model.MiddleName, model.LastName, model.Email, null);
    }

    public User ToModel(UserDto dto)
    {
        return new User(dto.FirstName, dto.MiddleName, dto.LastName, dto.Email, dto.Password);
    }
}