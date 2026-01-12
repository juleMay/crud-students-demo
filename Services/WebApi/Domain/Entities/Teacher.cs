using WebApi.Domain.ValueObjects;

namespace WebApi.Domain.Entities;

public class Teacher
{
    public Guid Id { get; }
    public FullName Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public virtual ICollection<CourseAssignment> CourseAssignments { get; private set; } = [];

    protected Teacher() { }

    private Teacher(FullName name, Email email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public static Teacher Create(FullName name, Email email)
    {
        if (string.IsNullOrWhiteSpace(name.ToString()))
        {
            throw new ArgumentException("Name is required");
        }
        if (string.IsNullOrWhiteSpace(email.ToString()))
        {
            throw new ArgumentException("Email is required");
        }
        return new Teacher(name, email);
    }
}
