using System;

namespace ClinicApi.Dtos.RoleDto.Update;

public class UpdateRoleDto
{
    public int Id { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string RoleArabName { get; set; } = string.Empty;
    public string Roletype { get; set; } = string.Empty;
}
