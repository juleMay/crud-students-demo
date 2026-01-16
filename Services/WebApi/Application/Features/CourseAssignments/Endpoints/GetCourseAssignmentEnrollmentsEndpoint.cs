using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.CourseAssignments.Queries;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Application.Features.CourseAssignments.Endpoints;

public class GetCourseAssignmentEnrollmentsEndpoint() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/course-assignments/{courseAssignmentId}/enrollments", GetCourseAssignmentEnrollments)
            .Produces<PagedList<GetCourseAssignmentEnrollmentsQueryResponse>>()
            .WithTags("CourseAssignments");
    }

    private static Task<PagedList<GetCourseAssignmentEnrollmentsQueryResponse>> GetCourseAssignmentEnrollments(
        [FromServices] IMediator _mediator,
        [FromRoute] Guid courseAssignmentId,
        [FromQuery] int page,
        [FromQuery] int pageSize,
        [FromQuery] string? sortBy,
        [FromQuery] string? sortDirection) => _mediator.Send(new GetCourseAssignmentEnrollmentsQuery(courseAssignmentId, new PagedRequestDto(page, pageSize, sortBy, sortDirection)));
}