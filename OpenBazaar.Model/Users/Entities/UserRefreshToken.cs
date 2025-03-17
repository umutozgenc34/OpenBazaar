using OpenBazaar.Shared.Entities;

namespace OpenBazaar.Model.Users.Entities;

public class UserRefreshToken : BaseEntity<string>
{
    public string Code { get; set; } = default!;
    public DateTime Expiration { get; set; }
}