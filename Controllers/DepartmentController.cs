using System.Security.Claims;
using ClinicApi.Data;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.Entity.Get;
using ClinicApi.Services;
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
        private readonly IAuditService _auditService;
        private readonly IEntityService _entityService;
        private readonly TokenRoles _tokenRoles;

        public DepartmentController(IAuditService auditService, IEntityService entityService, TokenRoles tokenRoles)
        {
            _auditService = auditService;
            _entityService = entityService;
            _tokenRoles = tokenRoles;
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<DepartmentDto>>> Get()
        {

            // await _auditService.PostAudit("View All Department For User");
            return Ok(await _entityService.GetAlldepartments());
        }
        [HttpGet("GetDeptEntity")]
        public async Task<ActionResult<List<DepartmentDto>>> GetDeptEntity()
        {

            await _auditService.PostAudit($"View All Department By EntityId With Id For User");
            return Ok(await _entityService.GetDeptEntity());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetSingle(int id)
        {

            await _auditService.PostAudit($"View Single Department By Id With id Number '{id}' For User");
            return Ok(await _entityService.GetDepartmentByID(id));
        }
        [HttpGet]
        [Route("GetSingleByEntity")]
        public async Task<ActionResult<List<DepartmentDto>>> GetSingleByEntity(int ByEntityid)
        {

            // await _auditService.PostAudit("View Single Department By EntityId For User");
            return Ok(await _entityService.GetDepartmentByEntityID(ByEntityid));
        }
        [HttpGet("GetCount")]
        public async Task<ActionResult<DepartmentDto>> GetCount()
        {

            // await _auditService.PostAudit("Get All Department Count By EntityId For User");
            var userEntity = _tokenRoles.GetRoleToken("EntityID");
            return Ok(await _entityService.GetDepartmentCountByEntityID(int.Parse(userEntity)));
        }
        [HttpPost]
        public async Task<ActionResult<List<DepartmentDto>>> AddNewDepartment(AddDepartmentDto newDepartment)
        {

            await _auditService.PostAudit($"Insert Department '{newDepartment.DepartmentName}' By User ");
            var userEntity = _tokenRoles.GetRoleToken("EntityID");
            // if (int.Parse(userEntity.Value.ToString()) != newDepartment.EntityId)
            //     return BadRequest("Entity Must Be The Same As You");
            return Ok(await _entityService.AddNewDepartment(newDepartment));
        }
        [HttpPost]
        [Route("EditDept")]
        public async Task<ActionResult<GetEntityDto>> UpdateDepartment(UpdateDepartmentDot updateDepartment)
        {
            var response = await _entityService.UpdateDepartment(updateDepartment);
            await _auditService.PutAudit($"Update Department With Id '{updateDepartment.Id}' To '{updateDepartment.DepartmentName}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetEntityDto>> DeleteDepartment(int id)
        // {
        //     return Ok(await _entityService.DeleteDepartment(id));
        // }
    }
}
