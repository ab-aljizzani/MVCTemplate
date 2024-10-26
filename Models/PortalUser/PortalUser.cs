using System;

namespace ClinicApi.Models.PortalUser;

public class PortalUser
{
    public int Id { get; set; }
    public string UserType { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public string Username { get; set; } = string.Empty;
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string LoginAttemp { get; set; } = string.Empty;
    public DateTime CreatedUser { get; set; }
    public bool UserExpires { get; set; }
}
