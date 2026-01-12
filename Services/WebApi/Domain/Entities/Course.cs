using WebApi.Domain.Enums;

namespace WebApi.Domain.Entities;

public class Course
{
    public Guid Id { get; }
    public string Name { get; private set; } = string.Empty;
    public int Credits { get; private set; }
    public virtual ICollection<CourseAssignment> Assignments { get; private set; } = [];

    protected Course() { }

    private Course(string name, int credits)
    {
        Id = Guid.NewGuid();
        Name = name;
        Credits = credits;
    }

    public static Course Create(string name, int credits)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }
        if (credits <= 0)
        {
            throw new ArgumentException("Credits must be greater than 0");
        }
        return new Course(name, credits);
    }

    public CourseAssignment AssignTeacher(Teacher teacher)
    {
        if (Assignments.Any(a => a.TeacherId == teacher.Id))
        {
            throw new InvalidOperationException("Teacher already assigned");
        }
        var assignment = CourseAssignment.Create(teacher.Id, Id);
        Assignments.Add(assignment);
        return assignment;
    }
}
