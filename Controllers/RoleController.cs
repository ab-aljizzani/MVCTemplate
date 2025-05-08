using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.RoleDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.RoleServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IRoleService _roleService;

        public RoleController(IAuditService auditService, IRoleService roleService)
        {
            _auditService = auditService;
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleDto>>> GetAllRole()
        {
            // await _auditService.PostAudit("View All Role For User");
            return Ok(await _roleService.GetAllRole());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RoleDto>>> GetRoleById(int id)
        {
            await _auditService.PostAudit($"View Single Role By Id With Id Number '{id}' For User");
            return Ok(await _roleService.GetRoleByID(id));
        }
        [HttpGet]
        [Route("GetRoleByEngName")]
        [AllowAnonymous]
        public async Task<ActionResult<List<RoleDto>>> GetRoleByEngName(string id)
        {
            await _auditService.PostAudit($"View Single Role By Name With Name '{id}' For User");
            return Ok(await _roleService.GetRoleByEngName(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<RoleDto>>> AddnewRole(RoleDto newRole)
        {
            await _auditService.PostAudit($"Insert Role '{newRole.Id + " " + newRole.RoleName}' By User ");
            return Ok(await _roleService.AddNewRole(newRole));
        }
        [HttpPost]
        [Route("EditRole")]
        public async Task<ActionResult<UpdateRoleDto>> UpdateRole(UpdateRoleDto updateRole)
        {
            var response = await _roleService.UpdateRole(updateRole);
            await _auditService.PutAudit($"Update Role For '{updateRole.Id + " To " + updateRole.RoleName}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<RoleDto>> DeleteRole(int id)
        // {
        //     return Ok(await _roleService.DeleteRole(id));
        // }
    }
}
