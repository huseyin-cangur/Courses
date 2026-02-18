

using Courses.Catalog.WebAPI.Features.Courses.Dtos;

namespace Courses.Catalog.WebAPI.Features.Courses.GetAll
{
    public class GetAllCourseQuery:IRequestByServiceResult<List<CourseDto>>
    {
         public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string? ImageUrl  { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }
    }
}