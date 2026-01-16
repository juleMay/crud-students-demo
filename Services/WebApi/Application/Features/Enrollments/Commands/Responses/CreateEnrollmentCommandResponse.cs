using WebApi.Application.Features.Enrollments.Dtos;

namespace WebApi.Application.Features.Enrollments.Commands.Responses;

public class CreateEnrollmentCommandResponse(Guid studentId, EnrollmentDto studentDto)
{
    public Guid EnrollmentId { get; set; } = studentId;
    public EnrollmentDto EnrollmentDto { get; set; } = studentDto;
}
