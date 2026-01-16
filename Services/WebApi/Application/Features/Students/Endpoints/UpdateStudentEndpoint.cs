using Carter;
using MediatR;
using WebApi.Application.Features.Students.Commands;

namespace WebApi.Application.Features.Students.Endpoints;

public class UpdateStudentEndpoint(IMediator _mediator) : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/students/{studentId}", UpdateStudent)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithTags("Students");
    }

    private Task UpdateStudent() => _mediator.Send(new UpdateStudentCommand());
}