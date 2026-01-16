using WebApi.Domain.Entities;
using WebApi.Domain.ValueObjects;

namespace WebApi.Application.Features.Students.Queries.Responses;

public class GetStudentByIdQueryResponse(Student? student)
{
    public Guid Id { get; } = student?.Id ?? Guid.Empty;
    public FullName Name { get; private set; } = student?.Name ?? FullName.Empty;
    public Email Email { get; private set; } = student?.Email ?? Email.Empty;
}
