using Microsoft.Extensions.DependencyInjection;
using MyLibrary.Domain.Authors;

namespace MyLibrary.Services.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorService, AuthorService>();
    }
}