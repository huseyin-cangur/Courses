
using Courses.Catalog.WebAPI.Features.Courses.Create;
using Courses.Catalog.WebAPI.Features.Courses.Dtos;

namespace Courses.Catalog.WebAPI.Features.Courses
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDto>();
            CreateMap<Feature, FeatureDto>();
        }
    }
}