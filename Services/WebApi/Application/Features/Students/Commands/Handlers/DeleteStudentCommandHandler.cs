using MediatR;
using WebApi.Application.Features.Students.Commands.Responses;

namespace WebApi.Application.Features.Students.Commands.Handlers;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeleteStudentCommandResponse>
{
    public Task<DeleteStudentCommandResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
