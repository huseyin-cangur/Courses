

using Courses.Catalog.WebAPI.Features.Categories.Dtos;

namespace Courses.Catalog.WebAPI.Features.Courses.Dtos
{
    public record CourseDto(Guid Id, string Name, string Description, decimal Price, string? ImageUrl, DateTime CreatedDate, Guid UserId, CategoryDto Category, FeatureDto Feature);
    
}