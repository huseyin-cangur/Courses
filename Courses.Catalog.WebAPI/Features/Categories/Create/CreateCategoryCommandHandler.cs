

using System.Net;
using Courses.Catalog.WebAPI.Repositories;
using MassTransit;

namespace Courses.Catalog.WebAPI.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (existCategory)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category already exist.", $"Category with name '{request.Name}' already exists.", HttpStatusCode.BadRequest);
            }

            var category = new Category
            {
                Id = NewId.NextSequentialGuid(),
                Name = request.Name
            };

            context.Categories.Add(category);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "empty");
        }
    }
}