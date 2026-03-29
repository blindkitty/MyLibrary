using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyLibrary.Database.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<LibraryDbContext>((_, options) =>
            options.UseNpgsql(connectionString));
    }
}