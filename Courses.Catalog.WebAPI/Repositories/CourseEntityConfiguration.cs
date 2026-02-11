

using Courses.Catalog.WebAPI.Features.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Courses.Catalog.WebAPI.Repositories
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToCollection("courses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.Name).HasElementName("name").HasMaxLength(100);
            builder.Property(c => c.Description).HasElementName("description").HasMaxLength(1000);
            builder.Property(c => c.CreatedDate).HasElementName("created_date");
            builder.Property(c => c.UserId).HasElementName("user_id");
            builder.Property(c => c.CategoryId).HasElementName("category_id");
            builder.Property(c => c.Price).HasElementName("price");
            builder.Property(c => c.Picture).HasElementName("picture");
            builder.OwnsOne(c => c.Feature, f =>
            {
                f.Property(f => f.Duration).HasElementName("duration");
                f.Property(f => f.Rating).HasElementName("rating");
                f.Property(f => f.EducatorFullName).HasElementName("educator_full_name");
            });
        }
    }
}