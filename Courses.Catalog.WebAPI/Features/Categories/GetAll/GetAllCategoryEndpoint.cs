

using Courses.Shared.Extensions;
 

namespace Courses.Catalog.WebAPI.Features.Categories.GetAll
{
    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllCategoryQuery())).ToResult()).WithName("GetAllCategories");

            return group;
        }
    }
}