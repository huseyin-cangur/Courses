
using Courses.Catalog.WebAPI.Features.Courses.Dtos;
using Courses.Catalog.WebAPI.Repositories;

namespace Courses.Catalog.WebAPI.Features.Courses.GetAll
{
    public class GetAllCourseQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCourseQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.ToListAsync(cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken);

            // foreach (var course in courses)
            // {
            //     course.Category = categories.FirstOrDefault(c => c.Id == course.CategoryId);
            // }

            var coursesAsDto = mapper.Map<List<CourseDto>>(courses);

            return ServiceResult<List<CourseDto>>.Success(coursesAsDto);
        }
    }
}