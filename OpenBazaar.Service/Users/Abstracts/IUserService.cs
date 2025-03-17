using OpenBazaar.Model.Users.Dtos;
using OpenBazaar.Shared.Responses;
using OpenBazaar.Shared.Security.Dtos;

namespace OpenBazaar.Service.Users.Abstracts;

public interface IUserService
{
    Task<ServiceResult<UserDto>> RegisterAsync(RegisterDto registerDto);
    Task<ServiceResult<UserDto>> GetUserByNameAsync(string userName);
    Task<ServiceResult<List<UserDto>>> GetAllAsync();
    Task<ServiceResult<UserDto>> GetByIdAsync(string id);
    Task<ServiceResult> UpdateAsync(string id, UpdateUserRequest request);
    Task<ServiceResult> DeleteAsync(string id);
}