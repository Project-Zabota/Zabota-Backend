namespace Zabota.Models;

public class User : BaseModel
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string? firstName, string? middleName, string? lastName, string? email, string? password)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    
    //public User(int id, 
    //    string? firstName, 
    //    string? middleName, 
    //    string? lastName, 
    //    string? email, 
    //    string? password) : this(firstName, middleName, lastName, email,  password)
    //{
    //    Id = id;
    //}
}