

using Courses.Shared.Extensions;

namespace Courses.Catalog.WebAPI.Features.Courses.GetAll
{
    public static class GetAllCourseEndPoint
    {
          public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllCourseQuery())).ToResult()).WithName("GetAllCourses");

            return group;
        }
    }
}