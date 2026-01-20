using MediatR;
using WebApi.Application.Features.Enrollments.Commands.Responses;
using WebApi.Domain.Entities;
using WebApi.Domain.Enums;
using WebApi.Infrastructure.Exceptions;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Enrollments.Commands.Handlers;

public class CreateEnrollmentCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateEnrollmentCommand, CreateEnrollmentCommandResponse>
{
    public Task<CreateEnrollmentCommandResponse> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
    {
        Validate(request);
        var enrollment = Enrollment.Create(request.EnrollmentDto);
        _unitOfWork.EnrollmentGenericRepository.Insert(enrollment);
        _unitOfWork.Save();
        return Task.FromResult(new CreateEnrollmentCommandResponse(enrollment.Id, request.EnrollmentDto));
    }

    public void Validate(CreateEnrollmentCommand request)
    {
        var errors = new List<string>();
        var student = _unitOfWork.StudentGenericRepository.GetById(request.EnrollmentDto.GetStudentId());
        if (student is null)
        {
            errors.Add("The student does not exist");
        }
        var course = _unitOfWork.CourseAssignmentRepository.GetById(request.EnrollmentDto.GetCourseAssignmentId());
        if (course is null)
        {
            errors.Add("The course does not exist");
        }
        var enrollments = _unitOfWork.EnrollmentRepository.GetAll(request.EnrollmentDto.GetStudentId());
        if (enrollments.Where(x => EnrollmentStatus.Active.Equals(x.Status)).Count() >= 3)
        {
            errors.Add("The student already has 3 enrollments");
        }

        if (errors.Count > 0)
        {
            throw new GenericValidationException(errors);
        }
    }
}
