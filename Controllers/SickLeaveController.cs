using ClinicApi.Dtos.SickLeaveDto.Get;
using ClinicApi.Dtos.SickLeaveDto.Insert;
using ClinicApi.Dtos.SickLeaveDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.SickLeaveServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SickLeaveController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ISickLeaveService _sickLeave;

        public SickLeaveController(IAuditService auditService, ISickLeaveService sickLeave)
        {
            _auditService = auditService;
            _sickLeave = sickLeave;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSickLeaveDto>>> GetAllSickLeave()
        {
            await _auditService.PostAudit("View All SickLeave For User");
            return Ok(await _sickLeave.GetAllSickLeave());
        }
        [HttpGet("GetAllCustom")]
        public async Task<ActionResult<List<object>>> GetAllCustomSickLeave()
        {
            await _auditService.PostAudit("View All SickLeave For User");
            return Ok(await _sickLeave.GetAllSickLeave());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetSickLeaveDto>>> GetSickLeaveById(int id)
        {
            await _auditService.PostAudit($"View Single SickLeave By Id With Id Number '{id}' For User");
            return Ok(await _sickLeave.GetSickLeaveByID(id));
        }
        [HttpGet]
        [Route("GetSickLeaveByAppointmentId")]
        public async Task<ActionResult<List<object>>> GetSickLeaveByAppointmentId(int id)
        {
            await _auditService.PostAudit($"View Single SickLeave By AppointmentId With AppointmentId Number '{id}' For User");
            return Ok(await _sickLeave.GetSickLeaveByAppointmentID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetSickLeaveDto>>> AddnewSickLeave(InsertSickLeaveDto newSickLeave)
        {
            await _auditService.PostAudit($"Insert SickLeave '{newSickLeave.Id + " " + newSickLeave.StartDate}' By User ");
            return Ok(await _sickLeave.AddNewSickLeave(newSickLeave));
        }
        [HttpPost]
        [Route("EditSickLeave")]
        public async Task<ActionResult<GetSickLeaveDto>> UpdateSickLeave(UpdateSickLeaveDto updateSickLeave)
        {
            var response = await _sickLeave.UpdateSickLeave(updateSickLeave);
            await _auditService.PutAudit($"Update SickLeave For '{updateSickLeave.Id + " To " + updateSickLeave.StartDate}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditSickLeaveSehaty")]
        public async Task<ActionResult<GetSickLeaveDto>> UpdateSickLeaveSehaty(UpdateSickLeaveSehatyDto updateSickLeave)
        {
            var response = await _sickLeave.UpdateSickLeaveSehaty(updateSickLeave);
            await _auditService.PutAudit($"Update SickLeave For '{updateSickLeave.AppointmentId + " To " + updateSickLeave}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetSickLeaveDto>> DeleteSickLeave(int id)
        // {
        //     return Ok(await _sickLeave.DeleteSickLeave(id));
        // }
    }
}
