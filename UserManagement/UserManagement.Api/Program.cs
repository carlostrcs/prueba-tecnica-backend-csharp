using UserManagement.Application.Services;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.Services;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración del repositorio de usuarios
var usersFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "users.json");

// Asegurar que el directorio exista
var dataDirectory = Path.GetDirectoryName(usersFilePath);
if (!Directory.Exists(dataDirectory))
{
    Directory.CreateDirectory(dataDirectory);
}

// Registro de servicios
builder.Services.AddSingleton<IUserRepository>(provider => new FileUserRepository(usersFilePath));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();