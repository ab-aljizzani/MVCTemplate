using System;

namespace MVCTemplate.Dtos.PortalUserModelDto.Update;

public class UpdatePortalUserRoleDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string UserType { get; set; } = string.Empty;
}
