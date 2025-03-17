﻿using Microsoft.AspNetCore.Mvc;
using OpenBazaar.Service.Auths.Abstracts;
using OpenBazaar.Service.Users.Abstracts;
using OpenBazaar.Shared.Security.Dtos;

namespace OpenBazaar.Api.Controllers;

public class AuthController(IAuthenticationService authenticationService, IUserService userService) : CustomBaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto) => CreateActionResult(await authenticationService.CreateTokenAsync(loginDto));

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto createUserDto)
       => CreateActionResult(await userService.RegisterAsync(createUserDto));

    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto) => CreateActionResult(await authenticationService.RevokeRefreshToken(refreshTokenDto.Token));
    [HttpPost("create-token-by-refresh-token")]
    public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto) => CreateActionResult(await authenticationService
        .CreateTokenByRefreshToken(refreshTokenDto.Token));
}