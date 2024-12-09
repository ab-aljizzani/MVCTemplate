using ClinicApi.Dtos.Entity;
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
        private readonly IEntityService _entityService;

        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetEntityDto>>> Get()
        {
            return Ok(await _entityService.GetAllEntitys());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEntityDto>> GetSingle(int id)
        {
            return Ok(await _entityService.GetEntityByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetEntityDto>>> AddnewEntity(AddEntityDto newEntity)
        {
            return Ok(await _entityService.AddNewEntity(newEntity));
        }
        [HttpPost]
        [Route("EditEntity")]
        public async Task<ActionResult<GetEntityDto>> UpdateEntity(UpdateEntityDto updateEntity)
        {
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
