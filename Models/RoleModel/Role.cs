using System;

namespace ClinicApi.Models.Role;

public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string RoleArabName { get; set; } = string.Empty;
    public string Roletype { get; set; } = string.Empty;
}
