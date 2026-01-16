using WebApi.Domain.Entities;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Infrastructure.Repositories.Contracts;

public interface IStudentRepository
{
    IQueryable<Student> GetAll(PagedRequestDto pagedRequest);
    bool IsEnrolled(Guid courseAssignmentId, Guid studentId);
}