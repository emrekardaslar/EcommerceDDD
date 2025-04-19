using EcommerceDDD.Domain.Common;

namespace EcommerceDDD.Domain.Entities.Users;

public class User : BaseEntity
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Role { get; private set; }
    public bool IsActive { get; private set; }

    private User() { } // For EF Core

    public User(string username, string email, string passwordHash, string role)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        IsActive = true;
    }

    public void UpdateDetails(string username, string email)
    {
        Username = username;
        Email = email;
        Update();
    }

    public void UpdatePassword(string passwordHash)
    {
        PasswordHash = passwordHash;
        Update();
    }

    public void Deactivate()
    {
        IsActive = false;
        Update();
    }

    public void Activate()
    {
        IsActive = true;
        Update();
    }
} 