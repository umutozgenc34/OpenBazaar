using OpenBazaar.Model.Users.Entities;
using OpenBazaar.Shared.Security.Dtos;

namespace OpenBazaar.Service.Tokens.Abstracts;

public interface ITokenService
{
    Task<TokenDto> CreateTokenAsync(User user);
}