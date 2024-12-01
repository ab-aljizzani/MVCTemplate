using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Models.DashboarUserModel;
[Index(nameof(Username), IsUnique = true)]
[Index(nameof(NationalId), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class DashboardUser
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string NationalId { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsFirstLogin { get; set; } = false;
    public int PersonalImgId { get; set; }
    public Models.PersonalImagesModel.PersonalImg? PersonalImage { get; set; }
    public string DateOfBirth { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserType { get; set; } = string.Empty;
    public Models.Entity.Entity? Entity { get; set; }
    public int EntityId { get; set; }
    public int DepartmentId { get; set; }
    public Models.Entity.Department? Department { get; set; }
    public int RoleId { get; set; }
    public Models.Role.Role? Role { get; set; }
    public int LoginAttemp { get; set; }
    public string LastLogin { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
    public bool PasswordExpires { get; set; }
    public string Status { get; set; } = string.Empty;
}
