using Carter;
using MediatR;
using WebApi.Application.Features.Students.Commands;

namespace WebApi.Application.Features.Students.Endpoints;

public class DeleteStudentEndpoint(IMediator _mediator) : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/students/{studentId}", DeleteStudent)
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithTags("Students");
    }

    private Task DeleteStudent() => _mediator.Send(new DeleteStudentCommand());
}