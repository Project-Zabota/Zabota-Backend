using Zabota.Models.Enums;

namespace Zabota.Dtos;

public class SenderDto
{
    public string Name { get; set; }
    public SenderType Type { get; set; }
    public UserDto? User { get; set; }

    public SenderDto(string name, SenderType type)
    {
        Name = name;
        Type = type;
    }

}