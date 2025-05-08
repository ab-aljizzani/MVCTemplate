using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.AppointmentDto.Insert;
using ClinicApi.Dtos.AppointmentDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.AppointmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStatusController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentStatusController(IAuditService auditService, IAppointmentService appointmentService)
        {
            _auditService = auditService;
            _appointmentService = appointmentService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AppointmentStatusDto>>> GetAllAppointmentStatus()
        {
            await _auditService.PostAudit("View All AppointmentStatus For User");
            return Ok(await _appointmentService.GetAllAppointmentStatus());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AppointmentStatusDto>>> GetAppointmentStatusById(int id)
        {
            await _auditService.PostAudit($"View Single AppointmentStatus By Id '{id}' For User");
            return Ok(await _appointmentService.GetAppointmentStatusByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<AppointmentStatusDto>>> AddnewAppointmentStatus(InsertAppointmentStatusDto insertAppointmentStatusDto)
        {
            await _auditService.PostAudit($"Insert NewAppointmentStatus With Id '{insertAppointmentStatusDto.Id + " AppointmentStatus " + insertAppointmentStatusDto.Status} By User ");
            return Ok(await _appointmentService.AddNewAppointmentStatus(insertAppointmentStatusDto));
        }
        [HttpPost]
        [Route("EditAppointmentStatus")]
        public async Task<ActionResult<AppointmentStatusDto>> UpdateAppointmentStatus(UpdateAppointmentStatusDto updateAppointment)
        {
            var response = await _appointmentService.UpdateAppointmentStatus(updateAppointment);
            await _auditService.PutAudit($"Update AppointmentStatus with Id '{updateAppointment.Id + " AppointmentStatus " + updateAppointment.Status} By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<AppointmentStatusDto>> DeleteAppointmentStatus(int id)
        // {
        //     return Ok(await _appointmentService.DeleteAppointmentStatus(id));
        // }
    }
}
