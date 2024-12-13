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
    public class AppointmentCotroller : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentCotroller(IAuditService auditService, IAppointmentService appointmentService)
        {
            _auditService = auditService;
            _appointmentService = appointmentService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AppointmentDto>>> GetAllAppointment()
        {
            await _auditService.PostAudit("View All Appointments For User");
            return Ok(await _appointmentService.GetAllAppointment());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentById(int id)
        {
            await _auditService.PostAudit($"View Single Appointment By Id '{id}' For User");
            return Ok(await _appointmentService.GetAppointmentByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<AppointmentDto>>> AddnewAppointment(InsertAppointmentDto insertAppointmentDto)
        {
            await _auditService.PostAudit($"Insert NewAppointment With Id '{insertAppointmentDto.Id + " ApponitmentDate " + insertAppointmentDto.ApponitmentDate + " And StartTime" + insertAppointmentDto.AppointmentStartTime + " And EndTime " + insertAppointmentDto.AppointmentEndTime}' By User ");
            return Ok(await _appointmentService.AddNewAppointment(insertAppointmentDto));
        }
        [HttpPost]
        [Route("EditAppointment")]
        public async Task<ActionResult<AppointmentDto>> UpdateAppointment(UpdateAppointmentDto updateAppointment)
        {
            await _auditService.PostAudit($"Update Appointment with Id '{updateAppointment.Id + " To ApponitmentDate " + updateAppointment.ApponitmentDate + " And StartTime" + updateAppointment.AppointmentStartTime + " And EndTime " + updateAppointment.AppointmentEndTime}' By User ");
            var response = await _appointmentService.UpdateAppointment(updateAppointment);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<AppointmentDto>> DeleteAppointment(int id)
        // {
        //     return Ok(await _appointmentService.DeleteAppointment(id));
        // }
    }
}
