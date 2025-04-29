using System;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.RoleDto.Update;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.RoleServices;

public interface IRoleService
{
    Task<ServiceResponse<List<RoleDto>>> GetAllRole();
    Task<ServiceResponse<RoleDto>> GetRoleByID(int id);
    Task<ServiceResponse<RoleDto>> GetRoleByEngName(string id);
    Task<ServiceResponse<List<RoleDto>>> AddNewRole(RoleDto newRole);
    Task<ServiceResponse<RoleDto>> UpdateRole(UpdateRoleDto updateRole);
    Task<ServiceResponse<RoleDto>> DeleteRole(int id);
}
