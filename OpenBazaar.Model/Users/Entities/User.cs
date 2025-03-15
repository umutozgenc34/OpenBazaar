using Microsoft.AspNetCore.Identity;
using OpenBazaar.Model.Listings.Entities;
using OpenBazaar.Shared.Entities;

namespace OpenBazaar.Model.Users.Entities;

public class User : IdentityUser, IAuditEntity
{
    public  required string FirstName { get; set; } 
    public required string LastName { get; set; } 
    public List<Listing> Listings { get; set; }
    public DateTime CreatedTime { get ; set ; }
    public DateTime UpdatedTime { get; set ; }
}
