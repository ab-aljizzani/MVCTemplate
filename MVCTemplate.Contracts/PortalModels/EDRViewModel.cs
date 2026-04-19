using MVCTemplate.Dtos.CountriesDto.Get;
using MVCTemplate.Dtos.PortalUserDto;
using MVCTemplate.Dtos.PortalUserModelDto.Insert;
using MVCTemplate.Dtos.RoleDto;

namespace MVCTemplatePortal.Models;

public class EDRViewModel
{
    public InsertPortalUserDto? PortalUserDto { get; set; }
    public List<RoleDto>? RoleDto { get; set; }
    public List<GetCountrieDto>? CountriesDto { get; set; }
    public string UserType { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int portalUserId { get; set; }
}
