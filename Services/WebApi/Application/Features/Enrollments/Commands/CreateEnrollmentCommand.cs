using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;
using WebApi.Application.Features.Enrollments.Dtos;

namespace WebApi.Application.Features.Enrollments.Commands;

public class CreateEnrollmentCommand(EnrollmentDto studentDto) : IRequest<CreateEnrollmentCommandResponse>
{
    public EnrollmentDto EnrollmentDto { get; set; } = studentDto;
}
