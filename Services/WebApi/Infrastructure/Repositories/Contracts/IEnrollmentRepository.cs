using WebApi.Domain.Entities;
using WebApi.Infrastructure.Pagination.Dtos;

namespace WebApi.Infrastructure.Repositories.Contracts;

public interface IEnrollmentRepository
{
    IQueryable<Enrollment> GetAll(Guid courseAssignmentId, PagedRequestDto pagedRequest);
    Enrollment? GetByStudentAndCourseAssignment(Guid studentId, Guid courseAssignmentId);
}