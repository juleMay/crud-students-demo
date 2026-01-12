using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Repositories.Contracts;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Student> StudentRepository { get; }
    IGenericRepository<Teacher> TeacherRepository { get; }
    IGenericRepository<Course> CourseRepository { get; }
    IGenericRepository<CourseAssignment> CourseAssignmentRepository { get; }
    IGenericRepository<Enrollment> EnrollmentRepository { get; }
    void Save();
}