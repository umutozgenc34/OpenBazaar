using OpenBazaar.Model.Listings.Dtos;

namespace OpenBazaar.Model.Categories.Dtos;

public sealed record CategoryWithListingsDto
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public List<ListingDto> Listings { get; init; } = new List<ListingDto>();
}
