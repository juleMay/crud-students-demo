using MediatR;
using WebApi.Application.Features.Students.Queries.Responses;

namespace WebApi.Application.Features.Students.Queries;

public class GetStudentByIdQuery(Guid studentId) : IRequest<GetStudentByIdQueryResponse>
{
    public Guid StudentId { get; set; } = studentId;
}
