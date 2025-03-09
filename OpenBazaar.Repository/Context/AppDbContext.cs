using Microsoft.EntityFrameworkCore;
using OpenBazaar.Model.Categories.Entities;

namespace OpenBazaar.Repository.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
