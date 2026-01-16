using WebApi.Domain.Entities;

namespace WebApi.Application.Features.CourseAssignments.Queries.Responses;

public class GetCourseAssignmentByIdQueryResponse
{
    public Guid Id { get; private set; }
    public string CourseName { get; private set; } 
    public string TeacherName { get; private set; }
    public int Credits { get; private set; }

    public GetCourseAssignmentByIdQueryResponse(){}
    public GetCourseAssignmentByIdQueryResponse(CourseAssignment courseAssignment)
    {
        Id = courseAssignment.Id;
        CourseName = courseAssignment.Course.Name;
        TeacherName = courseAssignment.Teacher.Name.ToString();
        Credits = courseAssignment.Course.Credits;
    }
}
