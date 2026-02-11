

using Courses.Catalog.WebAPI.Features.Courses;
using Courses.Catalog.WebAPI.Repositories;

namespace Courses.Catalog.WebAPI.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<Course>? Courses { get; set; }
    }
}