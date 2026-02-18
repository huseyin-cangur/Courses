
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Shared.Extensions
{
    public static class CommondServiceExt
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type type)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(type));
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(type);

            services.AddAutoMapper(type);

            return services;
        }
    }
}