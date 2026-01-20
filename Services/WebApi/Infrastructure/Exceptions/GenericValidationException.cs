namespace WebApi.Infrastructure.Exceptions;

public sealed class GenericValidationException(IReadOnlyList<string> errors) : AppException("Validation failed")
{
    public IReadOnlyList<string> Errors { get; } = errors;
    public override int StatusCode => StatusCodes.Status400BadRequest;
    public override string Title => "Validation Error";
    public override IReadOnlyList<string>? Details => Errors;
}
