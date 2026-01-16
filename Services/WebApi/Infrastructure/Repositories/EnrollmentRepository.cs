using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Infrastructure.Contexts;
using WebApi.Infrastructure.Pagination.Dtos;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Infrastructure.Repositories;

public class EnrollmentRepository(UniversityReadDbContext readDbContext) : IEnrollmentRepository
{
    private readonly UniversityReadDbContext _readDbContext = readDbContext;

    public IQueryable<Enrollment> GetAll(Guid courseAssignmentId, PagedRequestDto pagedRequest)
    {
        var query = _readDbContext.Enrollments
            .Include(x => x.CourseAssignment)
            .Include(x => x.Student)
            .Where(x => x.CourseAssignmentId.Equals(courseAssignmentId))
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagedRequest.SortBy))
        {
            var direction = string.IsNullOrWhiteSpace(pagedRequest.SortDirection)
                ? "asc"
                : pagedRequest.SortDirection;

            query = query.OrderBy($"{pagedRequest.SortBy} {direction}");
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }

        return query;
    }

    public Enrollment? GetByStudentAndCourseAssignment(Guid studentId, Guid courseAssignmentId)
    {
        var query = _readDbContext.Enrollments
            .Where(x => x.StudentId.Equals(studentId) && x.CourseAssignmentId.Equals(courseAssignmentId));
        return query.FirstOrDefault();
    }
}
