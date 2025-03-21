﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenBazaar.Service.Roles.Abstracts;

namespace OpenBazaar.Api.Controllers;

public class RolesController(IRoleService roleService) : CustomBaseController
{
    [Authorize(Roles = "Admin")]
    [HttpPost("CreateUserRoles/{userName}")]
    public async Task<IActionResult> CreateUserRoles(string userName, [FromBody] List<string> roles) => CreateActionResult(await roleService
       .CreateUserRolesAsync(userName, roles));
}