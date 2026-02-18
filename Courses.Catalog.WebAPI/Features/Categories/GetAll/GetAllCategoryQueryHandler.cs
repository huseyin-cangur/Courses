
 
using Courses.Catalog.WebAPI.Features.Categories.Dtos;
using Courses.Catalog.WebAPI.Repositories;
 
namespace Courses.Catalog.WebAPI.Features.Categories.GetAll
{
    public class GetAllCategoryQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<IList<CategoryDto>>>
    {
        public async Task<ServiceResult<IList<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories

                .ToListAsync(cancellationToken);

            var categoriesAsDto = mapper.Map<IList<CategoryDto>>(categories);    

            return ServiceResult<IList<CategoryDto>>.Success(categoriesAsDto);
        }
    }
}