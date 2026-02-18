

using Courses.Shared.Extensions;
 

namespace Courses.Catalog.WebAPI.Features.Categories.GetById
{
    public static class GetByIdCategoryEndpoint
    {
           public static RouteGroupBuilder GetCategoryByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) => (await mediator.Send(new GetCategoryByIdQuery(id))).ToResult()).WithName("GetByIdCategory");

            return group;
        }
    }
}