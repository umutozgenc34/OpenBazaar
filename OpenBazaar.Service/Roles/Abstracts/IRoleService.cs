using OpenBazaar.Shared.Responses;

namespace OpenBazaar.Service.Roles.Abstracts;

public interface IRoleService
{
    Task<ServiceResult> CreateUserRolesAsync(string userName, List<string> roles);
}