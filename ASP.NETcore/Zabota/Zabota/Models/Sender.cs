namespace Zabota.Models.Enums;

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

    public enum SenderType
    {
        CLIENT,
        EMPOLYEE_ZABOTA
    }
}