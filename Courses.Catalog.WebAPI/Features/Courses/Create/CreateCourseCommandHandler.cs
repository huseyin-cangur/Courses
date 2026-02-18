


using System.Net;
using Courses.Catalog.WebAPI.Repositories;
using MassTransit;

namespace Courses.Catalog.WebAPI.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken);
            if (!hasCategory)
            {
                return ServiceResult<Guid>.Error("Category not found.", $"Category with ID {request.CategoryId} does not exist.", HttpStatusCode.NotFound);
            }

            var course = mapper.Map<Course>(request);
            course.Id = NewId.NextSequentialGuid();
            course.Created = DateTime.UtcNow;

            course.Feature = new Feature
            {
                Duration = 10,
                EducatorFullName = "Hüseyin Yıldız",
                Rating = 5

            };

            context.Courses.Add(course);
            await context.SaveChangesAsync(cancellationToken);
            return ServiceResult<Guid>.SuccessAsCreated(course.Id, $"/api/courses/{course.Id}");
        }
    }
}