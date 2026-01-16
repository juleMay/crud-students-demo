using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.CourseAssignments.Queries;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Application.Features.CourseAssignments.Endpoints;

public class GetCourseAssignmentsEndpoint() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/course-assignments", GetCourseAssignments)
            .Produces<PagedList<GetCourseAssignmentsQueryResponse>>()
            .WithTags("CourseAssignments");
    }

    private static Task<PagedList<GetCourseAssignmentsQueryResponse>> GetCourseAssignments(
        [FromServices] IMediator _mediator,
        [FromQuery] int page,
        [FromQuery] int pageSize,
        [FromQuery] string? sortBy,
        [FromQuery] string? sortDirection) => _mediator.Send(new GetCourseAssignmentsQuery(new PagedRequestDto(page, pageSize, sortBy, sortDirection)));
}