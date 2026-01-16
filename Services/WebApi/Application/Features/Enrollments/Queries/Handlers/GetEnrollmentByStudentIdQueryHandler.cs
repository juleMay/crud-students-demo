using MediatR;
using WebApi.Application.Features.Enrollments.Queries.Responses;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.Enrollments.Queries.Handlers;

public class GetEnrollmentByStudentIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetEnrollmentByStudentIdQuery, GetEnrollmentByStudentIdQueryResponse>
{
    public Task<GetEnrollmentByStudentIdQueryResponse> Handle(GetEnrollmentByStudentIdQuery request, CancellationToken cancellationToken)
    {
        var enrollment = _unitOfWork.EnrollmentRepository.GetByStudentAndCourseAssignment(request.StudentId, request.CourseAssignmentId);
        if (enrollment is null)
        {
            return Task.FromResult(new GetEnrollmentByStudentIdQueryResponse());
        }
        return Task.FromResult(new GetEnrollmentByStudentIdQueryResponse(enrollment));
    }
}
