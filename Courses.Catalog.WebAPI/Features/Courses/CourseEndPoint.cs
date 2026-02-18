

using Courses.Catalog.WebAPI.Features.Courses.Create;
using Courses.Catalog.WebAPI.Features.Courses.Delete;
using Courses.Catalog.WebAPI.Features.Courses.GetAll;
using Courses.Catalog.WebAPI.Features.Courses.GetById;
using Courses.Catalog.WebAPI.Features.Courses.Update;

namespace Courses.Catalog.WebAPI.Features.Courses
{
    public static class CourseEndPoint
    {
        public static void AddCourseGroupEndpointExt(this WebApplication application)
        {
            application.MapGroup("api/courses").CreateCourseGroupItemEndpoint()
            .GetAllCourseGroupItemEndpoint().GetCourseByIdGroupItemEndpoint()
            .UpdateCourseGroupItemEndpoint().DeleteCourseGroupItemEndpoint()
            .WithTags("Courses");

        }
    }
}