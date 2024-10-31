using System;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Models.Entity;

namespace ClinicApi.Dtos.PortalUserDto;

public class PortalUserDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty;
    public Models.Entity.Entity? Entity { get; set; }
    public int EntityId { get; set; }
    public int RoleId { get; set; }
    public string LoginAttemp { get; set; } = string.Empty;
    public DateTime LastLogin { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool PasswordExpires { get; set; }
    public string Status { get; set; } = string.Empty;
}
