﻿namespace OpenBazaar.Shared.Security.Dtos;

public sealed record TokenDto(string AccessToken, DateTime AccessTokenExpiration, string RefreshToken, DateTime RefreshTokenExpiration);