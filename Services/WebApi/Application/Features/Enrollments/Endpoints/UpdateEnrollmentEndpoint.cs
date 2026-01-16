using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Enrollments.Commands;

namespace WebApi.Application.Features.Enrollments.Endpoints;

public class UpdateEnrollmentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/Enrollments/{enrollmentId}", UpdateEnrollment)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithTags("Enrollments");
    }

    private Task UpdateEnrollment([FromServices] IMediator _mediator, [FromRoute] Guid enrollmentId) => _mediator.Send(new UpdateEnrollmentCommand(enrollmentId));
}