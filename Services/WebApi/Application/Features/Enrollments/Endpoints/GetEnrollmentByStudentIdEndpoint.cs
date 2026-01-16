using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Enrollments.Queries;
using WebApi.Application.Features.Enrollments.Queries.Responses;

namespace WebApi.Application.Features.Enrollments.Endpoints;

public class GetEnrollmentByStudentIdEndpoint() : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/enrrollments/students/{studentId}/course-assignments/{courseAssignmentId}", GetCourseAssignments)
            .Produces<GetEnrollmentByStudentIdQueryResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Enrollments");
    }

    private static async Task<IResult> GetCourseAssignments([FromServices] IMediator _mediator, [FromRoute] Guid studentId, [FromRoute] Guid courseAssignmentId)
    {
       var courseAssignment = await _mediator.Send(new GetEnrollmentByStudentIdQuery(studentId, courseAssignmentId));
        if (courseAssignment is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(courseAssignment);
    } 
}