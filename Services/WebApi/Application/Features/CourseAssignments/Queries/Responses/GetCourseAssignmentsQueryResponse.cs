using WebApi.Domain.Entities;

namespace WebApi.Application.Features.CourseAssignments.Queries.Responses;

public class GetCourseAssignmentsQueryResponse(CourseAssignment courseAssignment)
{
    public Guid Id { get; set; } = courseAssignment.Id;
    public string CourseName { get; private set; } = courseAssignment.Course.Name;
    public string TeacherName { get; private set; } = courseAssignment.Teacher.Name.ToString();
    public int Credits { get; private set; } = courseAssignment.Course.Credits;
}
