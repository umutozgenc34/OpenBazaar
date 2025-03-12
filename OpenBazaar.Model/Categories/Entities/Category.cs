using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Shared.Entities;

namespace OpenBazaar.Model.Categories.Entities;

public class Category : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public List<Listing> Listings { get; set; } = new List<Listing>();
}
