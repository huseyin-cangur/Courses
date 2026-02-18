
using Courses.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Catalog.WebAPI.Features.Courses.Update
{
    public static class UpdateCourseEndPoint
    {
            public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/update", async (UpdateCourseCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.ToResult();
            })
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .WithName("UpdateCourse").WithTags("Courses");
            return group;
        }
    }
}