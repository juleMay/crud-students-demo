namespace WebApi.Infrastructure.Exceptions;

public sealed class NotFoundException(string entity, object key) : AppException($"{entity} not found")
{
    public string Entity { get; } = entity;
    public object Key { get; } = key;

    public override int StatusCode => StatusCodes.Status404NotFound;
    public override string Title => "Not Found";
}