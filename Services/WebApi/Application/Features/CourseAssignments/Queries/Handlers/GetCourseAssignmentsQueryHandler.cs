using MediatR;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;
using WebApi.Infrastructure.Pagination;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.CourseAssignments.Queries.Handlers;

public class GetCourseAssignmentsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCourseAssignmentsQuery, PagedList<GetCourseAssignmentsQueryResponse>>
{
    public Task<PagedList<GetCourseAssignmentsQueryResponse>> Handle(GetCourseAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var courseAssignments = _unitOfWork.CourseAssignmentRepository.GetAll(request.PagedRequest)
            .Select(x => new GetCourseAssignmentsQueryResponse(x));
        return PagedList<GetCourseAssignmentsQueryResponse>.Create(courseAssignments, request.PagedRequest.Page, request.PagedRequest.PageSize);
    }
}
