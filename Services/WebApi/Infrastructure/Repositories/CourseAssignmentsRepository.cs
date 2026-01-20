using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Infrastructure.Contexts;
using WebApi.Infrastructure.Pagination.Dtos;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Infrastructure.Repositories;

public class CourseAssignmentRepository(UniversityReadDbContext readDbContext) : ICourseAssignmentRepository
{
    private readonly UniversityReadDbContext _readDbContext = readDbContext;

    public IQueryable<CourseAssignment> GetAll(PagedRequestDto pagedRequest)
    {
        var query = _readDbContext.CourseAssignments
            .Include(x => x.Course)
            .Include(x => x.Teacher)
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

    public IQueryable<CourseAssignment> GetById(Guid courseId)
    {
        var query = _readDbContext.CourseAssignments
            .Include(x => x.Course)
            .Include(x => x.Teacher)
            .Include(x => x.Enrollments)
            .ThenInclude(x => x.Student)
            .Where(x => x.Id.Equals(courseId))
            .AsQueryable();

        return query;
    }
}
