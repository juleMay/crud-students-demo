using MediatR;
using WebApi.Application.Features.Students.Commands.Responses;
using WebApi.Domain.Entities;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Students.Commands.Handlers;

public class CreateStudentCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateStudentCommand, CreateStudentCommandResponse>
{
    public Task<CreateStudentCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = Student.Create(request.StudentDto);
        _unitOfWork.StudentGenericRepository.Insert(student);
        _unitOfWork.Save();
        return Task.FromResult(new CreateStudentCommandResponse(student.Id, request.StudentDto));
    }
}
