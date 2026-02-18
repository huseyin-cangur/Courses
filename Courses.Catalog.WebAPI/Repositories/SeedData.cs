

using Courses.Catalog.WebAPI.Features.Categories;
using Courses.Catalog.WebAPI.Features.Courses;
using Courses.Catalog.WebAPI.Repositories;
using MassTransit;
using MongoDB.Driver;

namespace Courses.Catalog.Api.Repositories;

public static class SeedData
{
    public static async Task AddSeedDataExt(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var mongoClient = scope.ServiceProvider.GetRequiredService<IMongoClient>();
        var database = mongoClient.GetDatabase("CatalogDb");



        var categories = database.GetCollection<Category>("Categories");
        var courses = database.GetCollection<Course>("Courses");

        if (await categories.CountDocumentsAsync(_ => true) == 0)
        {
            var categoryList = new List<Category>
            {
                new() { Id = NewId.NextSequentialGuid(), Name = "Development" },
                new() { Id = NewId.NextSequentialGuid(), Name = "Business" },
                new() { Id = NewId.NextSequentialGuid(), Name = "IT & Software" },
                new() { Id = NewId.NextSequentialGuid(), Name = "Office Productivity" },
                new() { Id = NewId.NextSequentialGuid(), Name = "Personal Development" }
            };

            await categories.InsertManyAsync(categoryList);
        }


        if (await courses.CountDocumentsAsync(_ => true) == 0)
        {
            var category = await categories.Find(_ => true).FirstAsync();
            var randomUserId = NewId.NextSequentialGuid();

            List<Course> courseList =
          [
              new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "C#",
                    Description = "C# Course",
                    Price = 100,
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    Feature = new Feature { Duration = 10, Rating = 4, EducatorFullName = "Ahmet Yıldız" },
                    CategoryId = category.Id
                },

                new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "Java",
                    Description = "Java Course",
                    Price = 200,
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    Feature = new Feature { Duration = 10, Rating = 4, EducatorFullName = "Ahmet Yıldız" },
                    CategoryId = category.Id
                },

                new()
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = "Python",
                    Description = "Python Course",
                    Price = 300,
                    UserId = randomUserId,
                    Created = DateTime.UtcNow,
                    Feature = new Feature { Duration = 10, Rating = 4, EducatorFullName = "Ahmet Yıldız" },
                    CategoryId = category.Id
                }
          ];

            await courses.InsertManyAsync(courseList);
        }

    }
}