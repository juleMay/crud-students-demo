namespace WebApi.Domain.ValueObjects;

public sealed record FullName
{
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string FirstSurname { get; }
    public string? SecondSurname { get; }

    private FullName() { }

    private FullName(string firstName, string firstSurname, string? middleName, string? secondSurname)
    {
        FirstName = firstName;
        MiddleName = middleName;
        FirstSurname = firstSurname;
        SecondSurname = secondSurname;
    }

    public static FullName Create(string firstName, string lastName, string? middleName, string? secondSurname)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name is required");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name is required");
        }

        return new FullName(firstName.Trim(), lastName.Trim(), middleName?.Trim(), secondSurname?.Trim());
    }

    public override string ToString() => $"{FirstName} {MiddleName} {FirstSurname} {SecondSurname}";

    public static FullName Empty => new();
}