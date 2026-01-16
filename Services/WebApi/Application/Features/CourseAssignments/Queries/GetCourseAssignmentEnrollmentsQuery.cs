using MediatR;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Application.Features.CourseAssignments.Queries;

public class GetCourseAssignmentEnrollmentsQuery(Guid courseAssignmentId, PagedRequestDto pagedRequest) : IRequest<PagedList<GetCourseAssignmentEnrollmentsQueryResponse>>
{
    public Guid CourseAssignmentId { get; set; } = courseAssignmentId;
    public PagedRequestDto PagedRequest { get; set; } = pagedRequest;
}
