using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Students.Queries;
using WebApi.Application.Features.Students.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Application.Features.Students.Endpoints;

public class GetStudentsEnrollmentsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/students/enrollments", GetStudentsEnrollments)
            .Produces<PagedList<GetStudentsEnrollmentsQueryResponse>>()
            .WithTags("Students");
    }

    private Task<PagedList<GetStudentsEnrollmentsQueryResponse>> GetStudentsEnrollments(
        [FromServices] IMediator _mediator,
        [FromQuery] int page,
        [FromQuery] int pageSize,
        [FromQuery] string? sortBy,
        [FromQuery] string? sortDirection) => _mediator.Send(new GetStudentsEnrollmentsQuery(new PagedRequestDto(page, pageSize, sortBy, sortDirection)));
}
