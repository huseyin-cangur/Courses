

using FluentValidation;

namespace Courses.Catalog.WebAPI.Features.Courses.Create
{
    public class CreateCourseCommandValidator:AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.").MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("CategoryId is required.").Must(id => id != Guid.Empty).WithMessage("CategoryId must be a valid GUID.");
        }
    }
}