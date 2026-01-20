using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;
using WebApi.Domain.Enums;
using WebApi.Infrastructure.Exceptions;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Enrollments.Commands.Handlers;

public class UpdateEnrollmentCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateEnrollmentCommand, UpdateEnrollmentCommandResponse>
{
    public Task<UpdateEnrollmentCommandResponse> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        Validate(request);
        var enrollment = _unitOfWork.EnrollmentGenericRepository.GetById(request.EnrollmentId);
        if (enrollment is not null)
        {
            enrollment.Reactivate();
            _unitOfWork.EnrollmentGenericRepository.Update(enrollment);
            _unitOfWork.Save();
        }
        return Task.FromResult(new UpdateEnrollmentCommandResponse());
    }

    public void Validate(UpdateEnrollmentCommand request)
    {
        var errors = new List<string>();
        var enrollment = _unitOfWork.EnrollmentGenericRepository.GetById(request.EnrollmentId);
        if (enrollment is null)
        {
            errors.Add("The enrollment does not exist");
        }
        else
        {
            var enrollments = _unitOfWork.EnrollmentRepository.GetAll(enrollment.StudentId);
            if (enrollments.Where(x => EnrollmentStatus.Active.Equals(x.Status)).Count() >= 3)
            {
                errors.Add("The student already has 3 enrollments");
            }
        }
        if (errors.Count > 0)
        {
            throw new GenericValidationException(errors);
        }
    }
}
