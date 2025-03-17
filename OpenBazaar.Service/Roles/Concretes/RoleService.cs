﻿using Microsoft.AspNetCore.Identity;
using OpenBazaar.Model.Users.Entities;
using OpenBazaar.Service.Roles.Abstracts;
using OpenBazaar.Shared.Responses;
using System.Net;

namespace OpenBazaar.Service.Roles.Concretes;
public class RoleService : IRoleService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ServiceResult> CreateUserRolesAsync(string userName, List<string> roles)
    {
        if (roles == null || !roles.Any())
        {
            return ServiceResult.Fail("The roles to be assigned should be specified.");
        }

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return ServiceResult.Fail("User not found.", HttpStatusCode.NotFound);
        }
        foreach (var role in roles)
        {

            if (!await _roleManager.RoleExistsAsync(role))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole { Name = role });
                if (!roleResult.Succeeded)
                {
                    return ServiceResult.Fail($"An error occurred while creating the role: {role}");
                }
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
            if (!addToRoleResult.Succeeded)
            {
                return ServiceResult.Fail($"An error occurred while assigning the role to the user.: {role}");
            }
        }

        return ServiceResult.Success("The roles has been successfully added.", HttpStatusCode.Created);
    }

}