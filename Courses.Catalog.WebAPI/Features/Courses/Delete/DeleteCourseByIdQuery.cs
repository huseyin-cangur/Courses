
namespace Courses.Catalog.WebAPI.Features.Courses.Delete
{
    public record DeleteCourseByIdQuery(Guid Id) : IRequestByServiceResult;

}