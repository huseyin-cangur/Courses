

using Courses.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Catalog.WebAPI.Features.Courses.Create
{
    public static class CreateCourseEndPoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/create", async (CreateCourseCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.ToResult();
            })
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .WithName("CreateCourse").WithTags("Courses");
            return group;
        }
    }
}