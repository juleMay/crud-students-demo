using MediatR;
using WebApi.Application.Features.Enrollments.Queries.Responses;

namespace WebApi.Application.Features.Enrollments.Queries;

public class GetEnrollmentByStudentIdQuery(Guid studentId, Guid courseAssignmentId) : IRequest<GetEnrollmentByStudentIdQueryResponse>
{
    public Guid StudentId { get; set; } = studentId;
    public Guid CourseAssignmentId { get; set; } = courseAssignmentId;
}
