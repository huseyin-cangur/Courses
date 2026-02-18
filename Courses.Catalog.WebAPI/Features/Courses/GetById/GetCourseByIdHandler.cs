

using System.Net;
using Courses.Catalog.WebAPI.Features.Courses.Dtos;
using Courses.Catalog.WebAPI.Repositories;

namespace Courses.Catalog.WebAPI.Features.Courses.GetById
{
    public class GetCourseByIdHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(request.Id, cancellationToken);
            if (course == null)
            {
                return ServiceResult<CourseDto>.Error("Course not found.", $"Course with ID {request.Id} does not exist.", HttpStatusCode.NotFound);
            }

            var courseDto = mapper.Map<CourseDto>(course);
            return ServiceResult<CourseDto>.Success(courseDto);
        }
    }
}