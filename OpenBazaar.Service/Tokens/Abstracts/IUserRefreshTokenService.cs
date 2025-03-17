using OpenBazaar.Model.Users.Entities;
using OpenBazaar.Shared.Repositories.Abstracts;

namespace OpenBazaar.Service.Tokens.Abstracts;

public interface IUserRefreshTokenService : IEfBaseRepository<UserRefreshToken, string>;