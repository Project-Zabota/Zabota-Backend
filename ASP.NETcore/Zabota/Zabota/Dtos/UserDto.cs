using Zabota.Models.Enums;

namespace Zabota.Dtos;

public class UserDto
{
    public int? Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Department Department { get; set; }

    public UserDto(int? id, string? firstName, string? middleName, string? lastName, string? email, string? password, Department department)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Email = email;
        Password = password;
        Department = department;
    }
}