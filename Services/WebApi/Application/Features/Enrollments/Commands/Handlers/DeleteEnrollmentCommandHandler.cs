using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Enrollments.Commands.Handlers;

public class DeleteEnrollmentCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteEnrollmentCommand, DeleteEnrollmentCommandResponse>
{
    public Task<DeleteEnrollmentCommandResponse> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
    {
        var enrollment = _unitOfWork.EnrollmentGenericRepository.GetById(request.EnrollmentId);
        if (enrollment is not null)
        {
            enrollment.Withdraw();
            _unitOfWork.EnrollmentGenericRepository.Update(enrollment);
            _unitOfWork.Save();
        }
        return Task.FromResult(new DeleteEnrollmentCommandResponse());
    }
}
