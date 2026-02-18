

 
using Courses.Catalog.WebAPI.Features.Categories.Dtos;

namespace Courses.Catalog.WebAPI.Features.Categories
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}