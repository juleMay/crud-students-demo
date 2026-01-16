using WebApi.Domain.Entities;

namespace WebApi.Application.Features.CourseAssignments.Queries.Responses;

public class GetCourseAssignmentEnrollmentsQueryResponse(Enrollment enrollment)
{
    public Guid Id { get; set; } = enrollment.Id;
    public string StudentName { get; private set; } = enrollment.Student.Name.ToString();
}
