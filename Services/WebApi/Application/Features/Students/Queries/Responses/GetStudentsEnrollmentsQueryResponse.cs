using WebApi.Domain.Entities;

namespace WebApi.Application.Features.Students.Queries.Responses;

public class GetStudentsEnrollmentsQueryResponse(Student student)
{
    public Guid Id { get; set; } = student.Id;
    public string StudentName { get; set; } = student.Name.ToString();
    public List<string> Enrollments { get; set; } = [.. student.Enrollments.Select(x => x.CourseAssignment.Course.Name)];
}
