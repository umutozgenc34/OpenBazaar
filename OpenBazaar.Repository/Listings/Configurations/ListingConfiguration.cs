using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBazaar.Model.Listings.Entities;

namespace OpenBazaar.Repository.Listings.Configurations;

public class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.ToTable("Listings");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(x => x.CreatedTime)
            .IsRequired();

        builder.Property(x => x.UpdatedTime)
            .IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(x => x.Category).AutoInclude();
    }
}
