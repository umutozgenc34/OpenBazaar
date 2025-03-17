using Microsoft.AspNetCore.Identity;
using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Shared.Entities;

namespace OpenBazaar.Model.Users.Entities;

public class User : IdentityUser, IAuditEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public List<Listing> Listings { get; set; }
    public DateTime CreatedTime { get ; set ; }
    public DateTime UpdatedTime { get; set ; }
}
