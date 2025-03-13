namespace OpenBazaar.Model.Listings.Dtos;

public sealed record ListingDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } 
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public List<string>? ImageUrls { get; init; }
    public string CategoryName { get; init; }
    public DateTime UpdatedTime { get; init; }
    public DateTime CreatedTime { get; init; }
}
