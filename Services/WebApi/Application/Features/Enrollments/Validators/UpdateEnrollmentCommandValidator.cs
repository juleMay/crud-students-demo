using FluentValidation;
using WebApi.Application.Features.Enrollments.Commands;

namespace WebApi.Application.Features.Enrollments.Validators;

public class UpdateEnrollmentCommandValidator : AbstractValidator<UpdateEnrollmentCommand>
{
    public UpdateEnrollmentCommandValidator()
    {
        RuleFor(x => x.EnrollmentId)
            .NotEmpty()
            .WithMessage("EnrollmentId is required");
    }
}
