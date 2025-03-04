namespace UserManagement.Domain.Services;

public interface IEmailService
{
    Task SendWelcomeEmailAsync(string email, string name);
}