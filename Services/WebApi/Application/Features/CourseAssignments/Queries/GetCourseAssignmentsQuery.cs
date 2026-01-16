using MediatR;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Application.Features.CourseAssignments.Queries;

public class GetCourseAssignmentsQuery(PagedRequestDto pagedRequest) : IRequest<PagedList<GetCourseAssignmentsQueryResponse>>
{
    public PagedRequestDto PagedRequest { get; set; } = pagedRequest;
}
