using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;

namespace WebApi.Application.Features.Enrollments.Commands;

public class UpdateEnrollmentCommand(Guid enrollmentId) : IRequest<UpdateEnrollmentCommandResponse>
{
    public Guid EnrollmentId {get; set;} = enrollmentId;
}
