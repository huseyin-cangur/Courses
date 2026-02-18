
namespace Courses.Catalog.WebAPI.Features.Courses.Update
{
    public record UpdateCourseCommand(Guid Id,
     string Name,
      string Description,
       decimal Price,
       string? ImageUrl,
        DateTime CreatedDate,
         Guid CategoryId) : IRequestByServiceResult;

}