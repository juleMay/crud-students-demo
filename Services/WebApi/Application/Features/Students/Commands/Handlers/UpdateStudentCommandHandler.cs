using MediatR;
using WebApi.Application.Features.Students.Commands.Responses;

namespace WebApi.Application.Features.Students.Commands.Handlers;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentCommandResponse>
{
    public Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
