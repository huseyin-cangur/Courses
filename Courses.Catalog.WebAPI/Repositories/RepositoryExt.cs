

using Courses.Catalog.WebAPI.Options;
using MongoDB.Driver;

namespace Courses.Catalog.WebAPI.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoOption>();
                var connectionString = options.ConnectionString;
                return new MongoClient(connectionString);
            });


            services.AddScoped(

                sp =>
                {
                    var mongoClient = sp.GetRequiredService<IMongoClient>();
                    var options = sp.GetRequiredService<MongoOption>();
                    return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
                }

            );
            return services;
        }
    }
}