using Microsoft.EntityFrameworkCore;
using OpenBazaar.Model.Categories.Entities;
using OpenBazaar.Model.Listings.Entities;
using System.Reflection;

namespace OpenBazaar.Repository.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Listing> Listings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
