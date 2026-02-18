
using Courses.Shared.Extensions;

namespace Courses.Catalog.WebAPI.Features.Courses.Delete
{
    public static class DeleteCourseEndpoint
    {
          public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) => (await mediator.Send(new DeleteCourseByIdQuery(id))).ToResult()).WithName("DeleteCourse");

            return group;
        }
    }
}