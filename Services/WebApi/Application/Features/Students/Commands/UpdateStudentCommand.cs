using MediatR;
using WebApi.Application.Features.Students.Commands.Responses;

namespace WebApi.Application.Features.Students.Commands;

public class UpdateStudentCommand : IRequest<UpdateStudentCommandResponse>
{
}
