using WebApi.Domain.Entities;
using WebApi.Domain.Enums;

namespace WebApi.Application.Features.Students.Queries.Responses;

public class GetStudentsEnrollmentsQueryResponse(Student student)
{
    public Guid Id { get; set; } = student.Id;
    public string StudentName { get; set; } = student.Name.ToString();
    public List<string> Enrollments { get; set; } = [.. student.Enrollments.Where(x => x.Status.Equals(EnrollmentStatus.Active)).Select(x => x.CourseAssignment.Course.Name)];
}
