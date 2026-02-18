

using Courses.Catalog.WebAPI.Features.Categories.Create;
using Courses.Catalog.WebAPI.Features.Categories.GetAll;
using Courses.Catalog.WebAPI.Features.Categories.GetById;

namespace Courses.Catalog.WebAPI.Features.Categories
{
    public static class CategoryEndPointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication application)
        {

            application.MapGroup("api/categories").CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetCategoryByIdGroupItemEndpoint().WithTags("Categories");
            
        }
    }
}