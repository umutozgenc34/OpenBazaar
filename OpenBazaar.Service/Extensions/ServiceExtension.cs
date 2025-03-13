using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OpenBazaar.Service.Categories.Abstracts;
using OpenBazaar.Service.Categories.Concretes;
using OpenBazaar.Service.Listings.Abstracts;
using OpenBazaar.Service.Listings.Concretes;

namespace OpenBazaar.Service.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServiceExtension(this IServiceCollection services,Type assembly)
    {
        services.AddAutoMapper(assembly);
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IListingService,ListingService>();

        return services;
    }
}
