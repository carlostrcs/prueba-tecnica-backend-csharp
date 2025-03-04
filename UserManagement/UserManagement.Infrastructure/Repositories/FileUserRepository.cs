using System.Text.Json;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Repositories;

public class FileUserRepository : IUserRepository
{
    private readonly string _filePath;
    private List<User> _users;

    public FileUserRepository(string filePath)
    {
        _filePath = filePath;
        _users = LoadUsersFromFile().GetAwaiter().GetResult();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return _users;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public async Task AddUserAsync(User user)
    {
        _users.Add(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            var index = _users.IndexOf(existingUser);
            _users[index] = user;
        }
    }

    public async Task SaveChangesAsync()
    {
        await SaveUsersToFile();
    }

    private async Task<List<User>> LoadUsersFromFile()
    {
        if (!File.Exists(_filePath))
        {
            return new List<User>();
        }

        var json = await File.ReadAllTextAsync(_filePath);
            
        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<User>();
        }

        return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }

    private async Task SaveUsersToFile()
    {
        var json = JsonSerializer.Serialize(_users, new JsonSerializerOptions 
        { 
            WriteIndented = true 
        });
            
        await File.WriteAllTextAsync(_filePath, json);
    }
}