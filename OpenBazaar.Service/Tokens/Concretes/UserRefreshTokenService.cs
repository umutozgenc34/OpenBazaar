using OpenBazaar.Model.Users.Entities;
using OpenBazaar.Repository.Context;
using OpenBazaar.Service.Tokens.Abstracts;
using OpenBazaar.Shared.Repositories.Concretes;

namespace OpenBazaar.Service.Tokens.Concretes;

public class UserRefreshTokenService(AppDbContext context) : EfBaseRepository<AppDbContext, UserRefreshToken, string>(context), IUserRefreshTokenService;