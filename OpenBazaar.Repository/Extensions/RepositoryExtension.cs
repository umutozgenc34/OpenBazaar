using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBazaar.Repository.Categories.Abstracts;
using OpenBazaar.Repository.Categories.Concretes;
using OpenBazaar.Repository.Context;
using OpenBazaar.Repository.Interceptors;
using OpenBazaar.Repository.Listings.Abstracts;
using OpenBazaar.Repository.Listings.Concretes;
using OpenBazaar.Repository.UnitOfWorks.Abstracts;
using OpenBazaar.Repository.UnitOfWorks.Concretes;

namespace OpenBazaar.Repository.Extensions;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositoryExtension(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IListingRepository,ListingRepository>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            options.AddInterceptors(new AuditDbContextInterceptor());
        });
        return services;
    }
}
