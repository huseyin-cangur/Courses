using Courses.Catalog.Api.Repositories;
using Courses.Catalog.WebAPI;
using Courses.Catalog.WebAPI.Features.Categories;
using Courses.Catalog.WebAPI.Features.Courses;
using Courses.Catalog.WebAPI.Options;
using Courses.Catalog.WebAPI.Repositories;
using Courses.Shared.Extensions;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

var app = builder.Build();

await app.AddSeedDataExt();

app.AddSeedDataExt().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data added successfully.");
});

app.AddCategoryGroupEndpointExt();
app.AddCourseGroupEndpointExt();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();

