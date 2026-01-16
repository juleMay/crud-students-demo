using MediatR;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;

namespace WebApi.Application.Features.CourseAssignments.Queries;

public class GetCourseAssignmentByIdQuery(Guid courseAssignmentId) : IRequest<GetCourseAssignmentByIdQueryResponse>
{
    public Guid CourseAssignmentId { get; set; } = courseAssignmentId;
}
