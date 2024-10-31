using System.Security.Claims;
using ClinicApi.Data;
using ClinicApi.Dtos.Entity;
using ClinicApi.Services.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IEntityService _entityService;
        private readonly TokenRoles _tokenRoles;

        public DepartmentController(IEntityService entityService, TokenRoles tokenRoles)
        {
            _entityService = entityService;
            _tokenRoles = tokenRoles;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<DepartmentDto>>> Get()
        {
            return Ok(await _entityService.GetAlldepartments());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetSingle(int id)
        {
            return Ok(await _entityService.GetDepartmentByID(id));
        }
        [HttpGet("GetCount")]
        public async Task<ActionResult<DepartmentDto>> GetCount()
        {
            var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            return Ok(await _entityService.GetDepartmentCountByEntityID(int.Parse(userEntity.Value.ToString())));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetEntityDto>>> AddNewDepartment(AddDepartmentDto newDepartment)
        {
            var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            if (int.Parse(userEntity.Value.ToString()) != newDepartment.EntityId)
                return BadRequest("Entity Must Be The Same As You");
            return Ok(await _entityService.AddNewDepartment(newDepartment));
        }
        [HttpPut]
        public async Task<ActionResult<GetEntityDto>> UpdateDepartment(UpdateDepartmentDot updateDepartment)
        {
            var response = await _entityService.UpdateDepartment(updateDepartment);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetEntityDto>> DeleteDepartment(int id)
        {
            return Ok(await _entityService.DeleteDepartment(id));
        }
    }
}
