using OpenBazaar.Model.Categories.Entities;
using OpenBazaar.Shared.Entities;

namespace OpenBazaar.Model.Listings.Entities;

public class Listing : BaseEntity<Guid>, IAuditEntity
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; } 
    public List<string>? ImageUrls { get; set; }
    public int CategoryId { get; set; } = default!;
    public Category Category { get; set; } = default!;
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
