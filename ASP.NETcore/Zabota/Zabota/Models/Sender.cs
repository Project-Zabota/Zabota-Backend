using Zabota.Models.Enums;

namespace Zabota.Models;

public class Sender : BaseModel
{
    public string Name { get; set; }
    public SenderType Type { get; set; }
    public User? User { get; set; }

    public Sender(string name, SenderType type)
    {
        Name = name;
        Type = type;
    }
    
    public Sender(string name, SenderType type, User? user) : this(name, type)
    {
        User = user;
    }

}