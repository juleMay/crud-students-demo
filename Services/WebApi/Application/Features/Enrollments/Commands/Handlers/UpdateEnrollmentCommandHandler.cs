using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Enrollments.Commands.Handlers;

public class UpdateEnrollmentCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateEnrollmentCommand, UpdateEnrollmentCommandResponse>
{
    public Task<UpdateEnrollmentCommandResponse> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment = _unitOfWork.EnrollmentGenericRepository.GetById(request.EnrollmentId);
        if (enrollment is not null)
        {
            enrollment.Reactivate();
            _unitOfWork.EnrollmentGenericRepository.Update(enrollment);
            _unitOfWork.Save();
        }
        return Task.FromResult(new UpdateEnrollmentCommandResponse());
    }
}
