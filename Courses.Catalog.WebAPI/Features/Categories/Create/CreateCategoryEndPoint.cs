

using Courses.Shared.Extensions;
using Courses.Shared.Filters;


namespace Courses.Catalog.WebAPI.Features.Categories.Create
{
    public static class CreateCategoryEndPoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/create", async (CreateCategoryCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.ToResult();
            }).WithName("CreateCategory").WithTags("Categories");
            return group;
        }
    }
}