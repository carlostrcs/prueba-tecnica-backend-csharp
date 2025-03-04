using System.ComponentModel.DataAnnotations;

namespace UserManagement.Application.DTOs;

public class CreateUserDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}