using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.PortalUserModelDto;

public class GetPortalUserDto
{
    public string UserFullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool IsFromShamel { get; set; } = false;
}
