

using System.ComponentModel.DataAnnotations;

namespace Courses.Catalog.WebAPI.Options
{
    public class MongoOption
    {
        [Required]
        public string ConnectionString { get; set; } = default!;
        [Required]
        public string DatabaseName { get; set; } = default!;
    }
}