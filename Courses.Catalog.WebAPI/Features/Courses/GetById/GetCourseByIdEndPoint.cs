

using Courses.Shared.Extensions;

namespace Courses.Catalog.WebAPI.Features.Courses.GetById
{
    public static class GetCourseByIdEndPoint
    {
        public static RouteGroupBuilder GetCourseByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) => (await mediator.Send(new GetCourseByIdQuery(id))).ToResult()).WithName("GetByIdCourse");

            return group;
        }
    }
}