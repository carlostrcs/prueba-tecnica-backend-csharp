namespace UserManagement.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        CreatedAt = DateTime.UtcNow;
    }
    
    public User() { }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }
}