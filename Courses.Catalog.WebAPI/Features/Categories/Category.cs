

using Courses.Catalog.WebAPI.Features.Courses;
using Courses.Catalog.WebAPI.Repositories;
using MongoDB.Bson.Serialization.Attributes;

namespace Courses.Catalog.WebAPI.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        [BsonIgnore]
        public ICollection<Course>? Courses { get; set; }
    }
}