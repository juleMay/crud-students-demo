using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;

namespace WebApi.Application.Features.Enrollments.Commands;

public class DeleteEnrollmentCommand(Guid enrollmentId) : IRequest<DeleteEnrollmentCommandResponse>
{
    public Guid EnrollmentId {get; set;} = enrollmentId;
}
