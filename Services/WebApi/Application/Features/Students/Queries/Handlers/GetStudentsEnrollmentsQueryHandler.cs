using MediatR;
using WebApi.Application.Features.Students.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Students.Queries.Handlers;

public class GetStudentsEnrollmentsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetStudentsEnrollmentsQuery, PagedList<GetStudentsEnrollmentsQueryResponse>>
{
    public Task<PagedList<GetStudentsEnrollmentsQueryResponse>> Handle(GetStudentsEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var students = _unitOfWork.StudentRepository.GetAll(request.PagedRequest)
            .Select(x => new GetStudentsEnrollmentsQueryResponse(x));
        return PagedList<GetStudentsEnrollmentsQueryResponse>.Create(students, request.PagedRequest.Page, request.PagedRequest.PageSize);
    }
}
