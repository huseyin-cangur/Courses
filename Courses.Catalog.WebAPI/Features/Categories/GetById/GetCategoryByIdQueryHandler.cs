

using System.Net;
using Courses.Catalog.WebAPI.Features.Categories.Dtos;
using Courses.Catalog.WebAPI.Repositories;
 

namespace Courses.Catalog.WebAPI.Features.Categories.GetById
{
    public class GetCategoryByIdQueryHandler(AppDbContext context,IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(request.Id);
            if (category == null)
                return ServiceResult<CategoryDto>.Error("Category not found",$"The category with id {request.Id} was not found.", HttpStatusCode.NotFound);

            var categoryDto = mapper.Map<CategoryDto>(category);

            return ServiceResult<CategoryDto>.Success(categoryDto);
        }
    }
}