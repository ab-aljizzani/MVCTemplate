using ClinicApi.Dtos.DoctorAvailbleTimeDto;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Insert;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Update;
using ClinicApi.Services;
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
        private readonly IAuditService _auditService;
        private readonly IDoctorAvailbleTimeService _doctorAvailbleTimeService;

        public DoctorAvailbleTimeController(IAuditService auditService, IDoctorAvailbleTimeService doctorAvailbleTimeService)
        {
            _auditService = auditService;
            _doctorAvailbleTimeService = doctorAvailbleTimeService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> GetAllTime()
        {
            await _auditService.PostAudit("View All DoctorAvailbleTime For User");
            return Ok(await _doctorAvailbleTimeService.GetAllTime());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> GetTimeById(int id)
        {
            await _auditService.PostAudit("View Single DoctorAvailbleTime By Id For User");
            return Ok(await _doctorAvailbleTimeService.GetTimeByID(id));
        }
        [HttpGet]
        [Route("ByDoctor")]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> GetTimeByDoctorId(int id)
        {
            await _auditService.PostAudit($"View Single DoctorAvailbleTime For Doctor '{id}' By User");
            return Ok(await _doctorAvailbleTimeService.GetTimeByDoctorID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> AddnewTime(InsertDoctorAvailbleTimeDto newTime)
        {
            await _auditService.PostAudit($"Insert DoctorAvailbleTime Id '{newTime.Id + " StartEndDate " + newTime.StartDate + ' ' + newTime.EndDate}' By User ");
            return Ok(await _doctorAvailbleTimeService.AddNewTime(newTime));
        }
        [HttpPost]
        [Route("EditTime")]
        public async Task<ActionResult<GetDoctorAvailbleTimeDto>> UpdateTime(UpdateDoctorAvailbleTimeDto updateTime)
        {
            await _auditService.PostAudit($"Update DoctorAvailbleTime with Id '{updateTime.Id + " To StartEndDate " + updateTime.StartDate + ' ' + updateTime.EndDate}' By User ");
            var response = await _doctorAvailbleTimeService.UpdateTime(updateTime);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditIsActive")]
        public async Task<ActionResult<List<GetDoctorAvailbleTimeDto>>> UpdateIsActive(UpdateDoctorIsActive updateTime)
        {
            await _auditService.PostAudit($"Update DoctorAvailbleTime with Id '{updateTime.Id + " Change IsActive To " + updateTime.IsActive}' By User ");
            var response = await _doctorAvailbleTimeService.UpdateIsActive(updateTime);
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
