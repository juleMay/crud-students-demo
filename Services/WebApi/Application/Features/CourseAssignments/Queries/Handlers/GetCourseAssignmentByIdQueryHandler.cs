using MediatR;
using WebApi.Application.Features.CourseAssignments.Queries.Responses;
using WebApi.Infrastructure.Repositories.Contracts;

namespace WebApi.Application.Features.CourseAssignments.Queries.Handlers;

public class GetCourseAssignmentByIdQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCourseAssignmentByIdQuery, GetCourseAssignmentByIdQueryResponse>
{
    public Task<GetCourseAssignmentByIdQueryResponse> Handle(GetCourseAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var courseAssignment = _unitOfWork.CourseAssignmentRepository.GetById(request.CourseAssignmentId).FirstOrDefault();
        if (courseAssignment is null)
        {
            return Task.FromResult(new GetCourseAssignmentByIdQueryResponse());
        }
        return Task.FromResult(new GetCourseAssignmentByIdQueryResponse(courseAssignment));
    }
}
