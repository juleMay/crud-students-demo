using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;
using WebApi.Domain.Entities;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Enrollments.Commands.Handlers;

public class CreateEnrollmentCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateEnrollmentCommand, CreateEnrollmentCommandResponse>
{
    public Task<CreateEnrollmentCommandResponse> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment = Enrollment.Create(request.EnrollmentDto);
        _unitOfWork.EnrollmentGenericRepository.Insert(enrollment);
        _unitOfWork.Save();
        return Task.FromResult(new CreateEnrollmentCommandResponse(enrollment.Id, request.EnrollmentDto));
    }
}
