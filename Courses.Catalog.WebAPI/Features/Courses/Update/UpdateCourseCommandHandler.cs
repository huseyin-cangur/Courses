


using Courses.Catalog.WebAPI.Repositories;

namespace Courses.Catalog.WebAPI.Features.Courses.Update
{
    public class UpdateCourseCommandHandler(AppDbContext context) : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(request.Id, cancellationToken);
            if (course == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            course.Name = request.Name;
            course.Description = request.Description;
            course.Price = request.Price;
            course.ImageUrl = request.ImageUrl;
            course.Created = request.CreatedDate;
            course.CategoryId = request.CategoryId;

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();

            
        }
    }
}