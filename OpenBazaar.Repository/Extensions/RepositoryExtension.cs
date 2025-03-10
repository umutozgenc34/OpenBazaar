using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBazaar.Repository.Categories.Abstracts;
using OpenBazaar.Repository.Categories.Concretes;
using OpenBazaar.Repository.Context;

namespace OpenBazaar.Repository.Extensions;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositoryExtension(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        return services;
    }
}
