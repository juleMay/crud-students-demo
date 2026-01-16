using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Features.Students.Commands;
using WebApi.Application.Features.Students.Commands.Responses;
using WebApi.Application.Features.Students.Dtos;

namespace WebApi.Application.Features.Students.Endpoints;

public class CreateStudentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/student", CreateStudent)
            .Produces<CreateStudentCommandResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithTags("Students");
    }

    private static async Task<IResult> CreateStudent([FromBody] StudentDto studentDto, [FromServices] IMediator mediator)
    {
        var student = await mediator.Send(new CreateStudentCommand(studentDto));
        return Results.Created($"api/student/{student.StudentId}", student.StudentDto);
    }
}