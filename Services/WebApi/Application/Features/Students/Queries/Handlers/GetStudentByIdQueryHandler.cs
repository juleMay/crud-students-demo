using MediatR;
using WebApi.Application.Features.Students.Queries.Responses;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Students.Queries.Handlers;

public class GetStudentByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResponse>
{
    public Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GetStudentByIdQueryResponse(_unitOfWork.StudentGenericRepository.GetById(request.StudentId)));
    }
}
