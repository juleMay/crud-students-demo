using MediatR;
using WebApi.Application.Features.Students.Commands.Responses;
using WebApi.Application.Features.Students.Dtos;

namespace WebApi.Application.Features.Students.Commands;

public class CreateStudentCommand(StudentDto studentDto) : IRequest<CreateStudentCommandResponse>
{
    public StudentDto StudentDto { get; set; } = studentDto;
}
