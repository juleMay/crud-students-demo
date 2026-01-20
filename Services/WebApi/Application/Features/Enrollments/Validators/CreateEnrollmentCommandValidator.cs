using FluentValidation;
using WebApi.Application.Features.Enrollments.Commands;

namespace WebApi.Application.Features.Enrollments.Validators;

public class CreateCreateEnrollmentCommandCommandValidator : AbstractValidator<CreateEnrollmentCommand>
{
    public CreateCreateEnrollmentCommandCommandValidator()
    {
        RuleFor(x => x.EnrollmentDto.GetStudentId())
            .NotEmpty()
            .WithMessage("StudentId is required");

        RuleFor(x => x.EnrollmentDto.GetCourseAssignmentId())
            .NotEmpty()
            .WithMessage("CourseAssignmentId is required");
    }
}
