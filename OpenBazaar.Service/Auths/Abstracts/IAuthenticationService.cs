﻿using OpenBazaar.Shared.Responses;
using OpenBazaar.Shared.Security.Dtos;

namespace OpenBazaar.Service.Auths.Abstracts;

public interface IAuthenticationService
{
    Task<ServiceResult<TokenDto>> CreateTokenAsync(LoginDto loginDto);
    Task<ServiceResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
    Task<ServiceResult> RevokeRefreshToken(string refreshToken);
}