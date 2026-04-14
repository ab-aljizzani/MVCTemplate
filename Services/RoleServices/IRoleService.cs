using System;
using MVCTemplate.Dtos.RoleDto;
using MVCTemplate.Dtos.RoleDto.Update;
using MVCTemplate.Models.Reponse;

namespace MVCTemplate.Services.RoleServices;

public interface IRoleService
{
    Task<ServiceResponse<List<RoleDto>>> GetAllRole();
    Task<ServiceResponse<RoleDto>> GetRoleByID(int id);
    Task<ServiceResponse<RoleDto>> GetRoleByEngName(string id);
    Task<ServiceResponse<List<RoleDto>>> AddNewRole(RoleDto newRole);
    Task<ServiceResponse<RoleDto>> UpdateRole(UpdateRoleDto updateRole);
    Task<ServiceResponse<RoleDto>> DeleteRole(int id);
}
