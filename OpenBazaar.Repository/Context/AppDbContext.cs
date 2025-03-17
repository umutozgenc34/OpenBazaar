using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenBazaar.Model.Categories.Entities;
using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Model.Users.Entities;
using System.Reflection;

namespace OpenBazaar.Repository.Context;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<User,IdentityRole,string>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Listing> Listings { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
