using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Infrastructure.Contexts;
using WebApi.Infrastructure.Pagination.Dtos;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Infrastructure.Repositories;

public class StudentRepository(UniversityReadDbContext readDbContext) : IStudentRepository
{
    private readonly UniversityReadDbContext _readDbContext = readDbContext;

    public IQueryable<Student> GetAll(PagedRequestDto pagedRequest)
    {
        var query = _readDbContext.Students
            .Include(x => x.Enrollments)
            .ThenInclude(x => x.CourseAssignment)
            .ThenInclude(x => x.Course)
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

    public bool IsEnrolled(Guid courseAssignmentId, Guid studentId)
    {
        var query = _readDbContext.Enrollments
            .Where(x => x.CourseAssignmentId.Equals(courseAssignmentId) && x.StudentId.Equals(studentId));
        return query.Any();
    }
}
