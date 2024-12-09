using ClinicApi.Dtos.Entity;
using ClinicApi.Services;
using ClinicApi.Services.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IEntityService _entityService;

        public EntityController(IAuditService auditService, IEntityService entityService)
        {
            _auditService = auditService;
            _entityService = entityService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetEntityDto>>> Get()
        {
            // await _auditService.PostAudit("View All Entity For User");
            return Ok(await _entityService.GetAllEntitys());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEntityDto>> GetSingle(int id)
        {
            // await _auditService.PostAudit("View Single Entity By Id For User");
            return Ok(await _entityService.GetEntityByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetEntityDto>>> AddnewEntity(AddEntityDto newEntity)
        {
            await _auditService.PostAudit($"Insert Entity '{newEntity.EntityName}' By User ");
            return Ok(await _entityService.AddNewEntity(newEntity));
        }
        [HttpPost]
        [Route("EditEntity")]
        public async Task<ActionResult<GetEntityDto>> UpdateEntity(UpdateEntityDto updateEntity)
        {
            await _auditService.PostAudit($"Update Entity With Id '{updateEntity.Id + " To " + updateEntity.EntityName}' By User ");
            var response = await _entityService.UpdateEntity(updateEntity);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetEntityDto>> DeleteEntity(int id)
        // {
        //     return Ok(await _entityService.DeleteEntity(id));
        // }
    }
}
