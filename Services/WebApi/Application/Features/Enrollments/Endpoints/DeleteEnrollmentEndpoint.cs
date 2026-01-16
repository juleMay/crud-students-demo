using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Enrollments.Commands;

namespace WebApi.Application.Features.Enrollments.Endpoints;

public class DeleteEnrollmentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/enrollments/{enrollmentId}", DeleteEnrollment)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Enrollments");
    }

    private Task<IResult> DeleteEnrollment([FromServices] IMediator _mediator, Guid enrollmentId)
    {
        _mediator.Send(new DeleteEnrollmentCommand(enrollmentId));
        return Task.FromResult(Results.NoContent());
    }
}