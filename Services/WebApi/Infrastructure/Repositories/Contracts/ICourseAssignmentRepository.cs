using WebApi.Domain.Entities;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Infrastructure.Repositories.Contracts;

public interface ICourseAssignmentRepository
{
    IQueryable<CourseAssignment> GetAll(PagedRequestDto pagedRequest);
    IQueryable<CourseAssignment> GetById(Guid courseId);
}
