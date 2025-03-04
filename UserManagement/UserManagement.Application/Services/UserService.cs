using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.Services;

namespace UserManagement.Application.Services;

public class UserService : IUserService
{
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(MapToDto);
        }

        public async Task<UserDTO?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user != null ? MapToDto(user) : null;
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto)
        {
            var user = new User(createUserDto.Name, createUserDto.Email);
            
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            
            // Simular envío de email
            await _emailService.SendWelcomeEmailAsync(user.Email, user.Name);
            
            return MapToDto(user);
        }

        public async Task<UserDTO?> UpdateUserAsync(Guid id, UpdateUserDTO updateUserDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            
            if (user == null)
                return null;
            
            user.Update(updateUserDto.Name, updateUserDto.Email);
            
            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();
            
            return MapToDto(user);
        }

        private static UserDTO MapToDto(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
}
