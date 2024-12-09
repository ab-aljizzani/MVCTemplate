using ClinicApi.Dtos.DoctorAvailbleTimeDto;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Insert;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Update;
using ClinicApi.Services.DoctorAvailbleTimeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailbleTimeController : ControllerBase
    {
        private readonly IDoctorAvailbleTimeService _doctorAvailbleTimeService;

        public DoctorAvailbleTimeController(IDoctorAvailbleTimeService doctorAvailbleTimeService)
        {
            _doctorAvailbleTimeService = doctorAvailbleTimeService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> GetAllTime()
        {
            return Ok(await _doctorAvailbleTimeService.GetAllTime());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> GetTimeById(int id)
        {
            return Ok(await _doctorAvailbleTimeService.GetTimeByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> AddnewTime(InsertDoctorAvailbleTimeDto newTime)
        {
            return Ok(await _doctorAvailbleTimeService.AddNewTime(newTime));
        }
        [HttpPost]
         [Route("EditTime")]
        public async Task<ActionResult<GetDoctorAvailbleTimeDto>> UpdateTime(UpdateDoctorAvailbleTimeDto updateTime)
        {
            var response = await _doctorAvailbleTimeService.UpdateTime(updateTime);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetDoctorAvailbleTimeDto>> DeleteTime(int id)
        // {
        //     return Ok(await _doctorAvailbleTimeService.DeleteTime(id));
        // }
    }
}
