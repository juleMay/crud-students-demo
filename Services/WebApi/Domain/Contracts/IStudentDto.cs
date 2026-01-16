using WebApi.Domain.ValueObjects;

namespace WebApi.Domain.Contracts;

public interface IStudentDto
{
    Guid? GetId();
    Email GetEmail();
    FullName GetFullName();
}