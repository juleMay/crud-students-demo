using WebApi.Domain.Entities;
using WebApi.Infrastructure.Contexts;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Infrastructure.Repositories;

public class UnitOfWork(UniversityWriteDbContext writeContext,
                        IGenericRepository<Student> studentRepository,
                        IGenericRepository<Teacher> teacherRepository,
                        IGenericRepository<Course> courseRepository,
                        IGenericRepository<CourseAssignment> courseAssignmentRepository,
                        IGenericRepository<Enrollment> enrollmentRepository) : IUnitOfWork
{

    public IGenericRepository<Student> StudentRepository { get; } = studentRepository;

    public IGenericRepository<Teacher> TeacherRepository { get; } = teacherRepository;

    public IGenericRepository<Course> CourseRepository { get; } = courseRepository;

    public IGenericRepository<CourseAssignment> CourseAssignmentRepository { get; } = courseAssignmentRepository;

    public IGenericRepository<Enrollment> EnrollmentRepository { get; } = enrollmentRepository;

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