using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Enrollments.Commands;
using WebApi.Application.Features.Enrollments.Commands.Responses;
using WebApi.Application.Features.Enrollments.Dtos;

namespace WebApi.Application.Features.Enrollments.Endpoints;

public class CreateEnrollmentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/enrollments", CreateEnrollment)
            .Produces<CreateEnrollmentCommandResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithTags("Enrollments");
    }

    private static async Task<IResult> CreateEnrollment([FromBody] EnrollmentDto studentDto, [FromServices] IMediator mediator)
    {
        var student = await mediator.Send(new CreateEnrollmentCommand(studentDto));
        return Results.Created($"api/enrollments/{student.EnrollmentId}", student.EnrollmentDto);
    }
}