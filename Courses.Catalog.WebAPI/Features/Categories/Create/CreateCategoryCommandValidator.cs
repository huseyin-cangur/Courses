

using FluentValidation;

namespace Courses.Catalog.WebAPI.Features.Categories.Create
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("{PropertyName} is required")
            .Length(4,25)
            .WithMessage("{PropertyName} must be between 4 and 25 characters");
        }
    }
}