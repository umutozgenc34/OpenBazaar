using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OpenBazaar.Service.Categories.Abstracts;
using OpenBazaar.Service.Categories.Concretes;
using OpenBazaar.Service.Listings.Abstracts;
using OpenBazaar.Service.Listings.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using OpenBazaar.Service.Roles.Abstracts;
using OpenBazaar.Service.Roles.Concretes;
using OpenBazaar.Service.Tokens.Abstracts;
using OpenBazaar.Service.Tokens.Concretes;
using OpenBazaar.Service.Users.Abstracts;
using OpenBazaar.Service.Users.Concretes;
using OpenBazaar.Shared.Security.Encryption;
using OpenBazaar.Shared.Security.Options;
using OpenBazaar.Service.Auths.Abstracts;
using OpenBazaar.Service.Auths.Concretes;

namespace OpenBazaar.Service.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServiceExtension(this IServiceCollection services,Type assembly,IConfiguration configuration)
    {
        services.AddAutoMapper(assembly);
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IRoleService, RoleService>();

        services.Configure<CustomTokenOption>(configuration.GetSection("TokenOption"));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
        {
            var tokenOptions = configuration.GetSection("TokenOption").Get<CustomTokenOption>();
            opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience[0],
                IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(5)
            };
        });

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IListingService,ListingService>();

        return services;
    }
}
