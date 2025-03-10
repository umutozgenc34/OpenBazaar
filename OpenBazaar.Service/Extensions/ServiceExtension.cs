using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace OpenBazaar.Service.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServiceExtension(this IServiceCollection services,Type assembly)
    {
        services.AddAutoMapper(assembly);
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);

        return services;
    }
}
