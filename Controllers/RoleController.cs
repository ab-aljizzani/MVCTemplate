using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.RoleDto.Update;
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
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleDto>>> GetAllRole()
        {
            return Ok(await _roleService.GetAllRole());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RoleDto>>> GetRoleById(int id)
        {
            return Ok(await _roleService.GetRoleByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<RoleDto>>> AddnewRole(RoleDto newRole)
        {
            return Ok(await _roleService.AddNewRole(newRole));
        }
        [HttpPost]
        [Route("EditRole")]
        public async Task<ActionResult<UpdateRoleDto>> UpdateRole(UpdateRoleDto updateRole)
        {
            var response = await _roleService.UpdateRole(updateRole);
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
