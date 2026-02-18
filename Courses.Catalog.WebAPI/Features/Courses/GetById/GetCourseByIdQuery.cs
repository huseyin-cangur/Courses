

using Courses.Catalog.WebAPI.Features.Courses.Dtos;

namespace Courses.Catalog.WebAPI.Features.Courses.GetById
{
    public record GetCourseByIdQuery(
        Guid Id
    ) : IRequestByServiceResult<CourseDto>;

}