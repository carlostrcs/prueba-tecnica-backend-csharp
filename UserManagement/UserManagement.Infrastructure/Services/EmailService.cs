using Microsoft.Extensions.Logging;
using UserManagement.Domain.Services;

namespace UserManagement.Infrastructure.Services;

public class EmailService: IEmailService
{
    private readonly ILogger _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public async Task SendWelcomeEmailAsync(string email, string name)
    {
        // Simulación del envío de email
        _logger.LogInformation($"Simulando envío de email de bienvenida a {name} ({email})");
            
        // En una implementación real, aquí se conectaría con un servicio de email
        await Task.CompletedTask;
    }
}