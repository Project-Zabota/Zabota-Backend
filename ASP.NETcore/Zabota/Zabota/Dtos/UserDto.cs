using Zabota.Models.Enums;

namespace Zabota.Dtos;

public class UserDto
{
    public int? Id;
    public string? FirstName;
    public string? MiddleName;
    public string? LastName;
    public string? Email;
    public string? Password;
    public Department Department;

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