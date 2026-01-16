using WebApi.Domain.Contracts;
using WebApi.Domain.ValueObjects;

namespace WebApi.Application.Features.Students.Dtos;

public class StudentDto(string firstName, string? middleName, string firstSurname, string? secondSurname, string emailAddress) : IStudentDto
{
    public string FirstName { get; set; } = firstName;
    public string? MiddleName { get; set; } = middleName;
    public string FirstSurname { get; set; } = firstSurname;
    public string? SecondSurname { get; set; } = secondSurname;
    public string EmailAddress { get; set; } = emailAddress;
    public Guid? GetId() => null;
    public Email GetEmail() => Email.Create(EmailAddress);
    public FullName GetFullName() => FullName.Create(FirstName, FirstSurname, MiddleName, SecondSurname);
}
