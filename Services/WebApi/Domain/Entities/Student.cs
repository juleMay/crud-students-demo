using WebApi.Domain.Contracts;
using WebApi.Domain.ValueObjects;

namespace WebApi.Domain.Entities;

public class Student
{
    public Guid Id { get; }
    public FullName Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public virtual ICollection<Enrollment> Enrollments { get; private set; } = [];

    protected Student() { }

    private Student(FullName name, Email email)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public static Student Create(IStudentDto studentDto)
    {
        return Create(studentDto.GetFullName(), studentDto.GetEmail());
    }

    public static Student Create(FullName name, Email email)
    {
        if (string.IsNullOrWhiteSpace(name.ToString()))
        {
            throw new ArgumentException("Name is required");
        }
        if (string.IsNullOrWhiteSpace(email.ToString()))
        {
            throw new ArgumentException("Email is required");
        }
        return new Student(name, email);
    }
}
