using MediatR;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.CourseAssignments.Queries.Handlers;

public class GetCourseAssignmentEnrollmentsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCourseAssignmentEnrollmentsQuery, PagedList<GetCourseAssignmentEnrollmentsQueryResponse>>
{
    public Task<PagedList<GetCourseAssignmentEnrollmentsQueryResponse>> Handle(GetCourseAssignmentEnrollmentsQuery request, CancellationToken cancellationToken)
    {
        var enrollments = _unitOfWork.EnrollmentRepository.GetAll(request.CourseAssignmentId, request.PagedRequest)
            .Select(x => new GetCourseAssignmentEnrollmentsQueryResponse(x));
        return PagedList<GetCourseAssignmentEnrollmentsQueryResponse>.Create(enrollments, request.PagedRequest.Page, request.PagedRequest.PageSize);
    }
}
