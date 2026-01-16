using WebApi.Domain.Contracts;

namespace WebApi.Application.Features.Enrollments.Dtos;

public class EnrollmentDto(Guid studentId, Guid courseAssignmentId, Guid? id = null) : IEnrollmentDto
{
    public Guid? Id { get; set; } = id;
    public Guid StudentId { get; set; } = studentId;
    public Guid CourseAssignmentId { get; set; } = courseAssignmentId;
    public Guid GetCourseAssignmentId() => CourseAssignmentId;
    public Guid? GetId() => Id;
    public Guid GetStudentId() => StudentId;
}
