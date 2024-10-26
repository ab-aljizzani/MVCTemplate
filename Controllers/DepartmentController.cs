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
    public class DepartmentController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public DepartmentController(IEntityService entityService)
        {
            _entityService = entityService;
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
        [HttpPost]
        public async Task<ActionResult<List<GetEntityDto>>> AddNewDepartment(AddDepartmentDto newDepartment)
        {
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
