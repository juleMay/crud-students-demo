using WebApi.Application.Features.Students.Dtos;

namespace WebApi.Application.Features.Students.Commands.Responses;

public class CreateStudentCommandResponse(Guid studentId, StudentDto studentDto)
{
    public Guid StudentId { get; set; } = studentId;
    public StudentDto StudentDto { get; set; } = studentDto;
}
