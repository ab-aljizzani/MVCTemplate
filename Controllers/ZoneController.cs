using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Dtos.ZoneModelDto.Update;
using ClinicApi.Services.ZoneServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneSerice _zoneSerice;

        public ZoneController(IZoneSerice zoneSerice)
        {
            _zoneSerice = zoneSerice;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ZoneDto>>> Get()
        {
            return Ok(await _zoneSerice.GetAllZone());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ZoneDto>> GetSingle(int id)
        {
            return Ok(await _zoneSerice.GetZoneByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<ZoneDto>>> AddnewZone(ZoneDto newZone)
        {
            return Ok(await _zoneSerice.AddNewZone(newZone));
        }
        [HttpPost]
        [Route("EditZone")]
        public async Task<ActionResult<ZoneDto>> UpdateZone(UpdateZoneDto updateZone)
        {
            var response = await _zoneSerice.UpdateZone(updateZone);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<ZoneDto>> DeleteZone(int id)
        // {
        //     return Ok(await _zoneSerice.DeleteZone(id));
        // }
    }
}
