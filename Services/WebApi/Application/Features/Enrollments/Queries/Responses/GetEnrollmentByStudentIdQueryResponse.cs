using WebApi.Domain.Entities;
using WebApi.Domain.Enums;

namespace WebApi.Application.Features.Enrollments.Queries.Responses;

public class GetEnrollmentByStudentIdQueryResponse
{
    public Guid Id { get; private set; }
    public EnrollmentStatus Status { get; private set; }
    public DateTime EnrolledAt { get; private set; }
    public DateTime? WithdrawnAt { get; private set; }

    public GetEnrollmentByStudentIdQueryResponse() { }
    public GetEnrollmentByStudentIdQueryResponse(Enrollment enrollment)
    {
        Id = enrollment.Id;
        Status = enrollment.Status;
        EnrolledAt = enrollment.EnrolledAt;
        WithdrawnAt = enrollment.WithdrawnAt;
    }
}
