using Microsoft.AspNetCore.Identity;
using OpenBazaar.Model.Users.Entities;
using OpenBazaar.Repository.Context;
using OpenBazaar.Repository.Extensions;
using OpenBazaar.Service;
using OpenBazaar.Service.Extensions;
using OpenBazaar.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositoryExtension(builder.Configuration)
    .AddServiceExtension(typeof(ServiceAssembly))
    .AddSharedExtension(builder.Configuration);

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
