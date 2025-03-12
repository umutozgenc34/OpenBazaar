using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenBazaar.Shared.Services.CloudinaryServices;
using OpenBazaar.Shared.Services.CloudinaryServices.Abstracts;
using OpenBazaar.Shared.Services.CloudinaryServices.Concretes;

namespace OpenBazaar.Shared.Extensions;

public static class SharedExtension
{
    public static IServiceCollection AddSharedExtension(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<ICloudinaryService, CloudinaryService>();

        services.Configure<CloudinarySettings>(options =>
        {
            configuration.GetSection("CloudinarySettings").Bind(options);
        });
        return services;
    }
}
