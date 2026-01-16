using WebApi.Domain.Entities;
using WebApi.Infrastructure.Contexts;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Infrastructure.Repositories;

public class UnitOfWork(UniversityWriteDbContext writeContext,
                        IStudentRepository studentRepository,
                        IGenericRepository<Student> studentGenericRepository,
                        IGenericRepository<Teacher> teacherRepository,
                        IGenericRepository<Course> courseRepository,
                        ICourseAssignmentRepository courseAssignmentRepository,
                        IGenericRepository<Enrollment> enrollmentGenericRepository,
                        IEnrollmentRepository enrollmentRepository) : IUnitOfWork
{

    public IStudentRepository StudentRepository { get; } = studentRepository;
    public IGenericRepository<Student> StudentGenericRepository { get; } = studentGenericRepository;

    public IGenericRepository<Teacher> TeacherRepository { get; } = teacherRepository;

    public IGenericRepository<Course> CourseRepository { get; } = courseRepository;

    public ICourseAssignmentRepository CourseAssignmentRepository { get; } = courseAssignmentRepository;

    public IGenericRepository<Enrollment> EnrollmentGenericRepository { get; } = enrollmentGenericRepository;
    public IEnrollmentRepository EnrollmentRepository { get; } = enrollmentRepository;

    private readonly UniversityWriteDbContext _writeContext = writeContext;

    private bool disposed = false;


    public void Save()
    {
        _writeContext.SaveChanges();
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!disposed && disposing)
        {
            _writeContext.Dispose();
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}