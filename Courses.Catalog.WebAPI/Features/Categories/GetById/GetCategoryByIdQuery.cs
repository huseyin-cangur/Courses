

using Courses.Catalog.WebAPI.Features.Categories.Dtos;
 

namespace Courses.Catalog.WebAPI.Features.Categories.GetById
{
    public class GetCategoryByIdQuery: IRequestByServiceResult<CategoryDto>
    {
         public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }

       
    }
}