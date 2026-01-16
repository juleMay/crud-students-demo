using MediatR;
using WebApi.Application.Features.Students.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Application.Features.Students.Queries;

public class GetStudentsEnrollmentsQuery(PagedRequestDto pagedRequest) : IRequest<PagedList<GetStudentsEnrollmentsQueryResponse>>
{
    public PagedRequestDto PagedRequest { get; set; } = pagedRequest;
}
