using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Students.Queries;
using WebApi.Application.Features.Students.Queries.Responses;

namespace WebApi.Application.Features.Students.Endpoints;

public class GetStudentByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/students/{studentId}", GetStudentById)
            .Produces<GetStudentByIdQueryResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Students");
    }

    private static async Task<IResult> GetStudentById([FromRoute] Guid studentId, [FromServices] IMediator mediator)
    {
        var student = await mediator.Send(new GetStudentByIdQuery(studentId));
        if (student is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(student);
    }
}
