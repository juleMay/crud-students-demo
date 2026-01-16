using WebApi.Domain.Enums;

namespace WebApi.Domain.Entities;

public class CourseAssignment
{
    public Guid Id { get; }
    public Guid TeacherId { get; }
    public Guid CourseId { get; }
    public DateTime AssignedAt { get; private set; }
    public virtual Teacher Teacher { get; } = null!;
    public virtual Course Course { get; } = null!;
    public virtual ICollection<Enrollment> Enrollments { get; private set; } = [];

    protected CourseAssignment() { }

    private CourseAssignment(Guid teacherId, Guid courseId)
    {
        Id = Guid.NewGuid();
        TeacherId = teacherId;
        CourseId = courseId;
        AssignedAt = DateTime.UtcNow;
    }

    public static CourseAssignment Create(Guid teacherId, Guid courseId)
    {
        if (teacherId == Guid.Empty)
        {
            throw new ArgumentException("Teacher is required");
        }
        if (courseId == Guid.Empty)
        {
            throw new ArgumentException("Course is required");
        }
        return new CourseAssignment(teacherId, courseId);
    }

    // public Enrollment EnrollStudent(Student student)
    // {
    //     if (Enrollments.Any(e => e.StudentId == student.Id && e.Status == EnrollmentStatus.Active))
    //     {
    //         throw new InvalidOperationException("Student already enrolled");
    //     }
    //     var enrollment = Enrollment.Create(student.Id, Id);
    //     Enrollments.Add(enrollment);
    //     return enrollment;
    // }
}
