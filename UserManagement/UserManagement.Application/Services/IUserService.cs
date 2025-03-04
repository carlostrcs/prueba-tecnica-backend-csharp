using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<UserDTO?> GetUserByIdAsync(Guid id);
    Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto);
    Task<UserDTO?> UpdateUserAsync(Guid id, UpdateUserDTO updateUserDto);
}