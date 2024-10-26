using System;

namespace ClinicApi.Dtos.PortalUserDto;

public class PortalUserDto
{
    public string UserType { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string LoginAttemp { get; set; } = string.Empty;
    public DateTime CreatedUser { get; set; }
    public bool UserExpires { get; set; }
}
