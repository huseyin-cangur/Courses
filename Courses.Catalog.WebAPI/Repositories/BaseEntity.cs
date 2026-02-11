

using MongoDB.Bson.Serialization.Attributes;

namespace Courses.Catalog.WebAPI.Repositories
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        public Guid Id { get; set; }
    }
}