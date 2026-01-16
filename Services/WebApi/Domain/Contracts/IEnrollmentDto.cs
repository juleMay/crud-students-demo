using WebApi.Domain.ValueObjects;

namespace WebApi.Domain.Contracts;

public interface IEnrollmentDto
{
    Guid? GetId();
    Guid GetStudentId();
    Guid GetCourseAssignmentId();
}