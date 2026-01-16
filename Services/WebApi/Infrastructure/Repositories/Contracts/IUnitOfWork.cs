using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Repositories.Contracts;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository StudentRepository { get; }
    IGenericRepository<Student> StudentGenericRepository { get; }
    IGenericRepository<Teacher> TeacherRepository { get; }
    IGenericRepository<Course> CourseRepository { get; }
    ICourseAssignmentRepository CourseAssignmentRepository { get; }
    IGenericRepository<Enrollment> EnrollmentGenericRepository { get; }
    IEnrollmentRepository EnrollmentRepository { get; }
    void Save();
}