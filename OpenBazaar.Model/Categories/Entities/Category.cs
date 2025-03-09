using OpenBazaar.Shared.Entities;

namespace OpenBazaar.Model.Categories.Entities;

public class Category : BaseEntity<int>
{
    public string Name { get; set; } = default!;
}
