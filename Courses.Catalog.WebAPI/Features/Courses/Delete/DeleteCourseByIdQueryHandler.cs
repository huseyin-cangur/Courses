


using Courses.Catalog.WebAPI.Repositories;

namespace Courses.Catalog.WebAPI.Features.Courses.Delete
{
    public class DeleteCourseByIdQueryHandler(AppDbContext context) : IRequestHandler<DeleteCourseByIdQuery, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FindAsync(request.Id, cancellationToken);
            if (course == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            context.Courses.Remove(course);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}