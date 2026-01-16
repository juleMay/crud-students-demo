using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.CourseAssignments.Queries;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;

namespace WebApi.Application.Features.CourseAssignments.Endpoints;

public class GetCourseAssignmentByIdEndpoint() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/course-assignments/{courseAssignmentId}", GetCourseAssignments)
            .Produces<GetCourseAssignmentByIdQueryResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("CourseAssignments");
    }

    private static async Task<IResult> GetCourseAssignments([FromServices] IMediator _mediator, [FromRoute] Guid courseAssignmentId)
    {
       var courseAssignment = await _mediator.Send(new GetCourseAssignmentByIdQuery(courseAssignmentId));
        if (courseAssignment is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(courseAssignment);
    } 
}