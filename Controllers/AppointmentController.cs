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
    public class AppointmentController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAuditService auditService, IAppointmentService appointmentService)
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
        [HttpGet]
        [Route("GetAppointmentByReqId")]
        public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentByReqId(int id)
        {
            await _auditService.PostAudit($"View Single Appointment By Req Id '{id}' For User");
            return Ok(await _appointmentService.GetAppointmentByReqID(id));
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
        [HttpPost]
        [Route("EditIsPersonShowup")]
        public async Task<ActionResult<AppointmentDto>> EditIsPersonShowup(UpdateIsPersonShowup updateAppointment)
        {
            // await _auditService.PostAudit($"Update Appointment IsPersonShowUp with AppointmentReq Id '{updateAppointment.RequestId + " To IsPersonShowUp " + updateAppointment.IsPersonShowUp}' By User ");
            var response = await _appointmentService.UpdateIsPersonShowUp(updateAppointment);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditSurvTypeIdByReqId")]
        public async Task<ActionResult<AppointmentDto>> EditSurvTypeIdByReqId(UpdateAppointmentSurveyTypeIdDto updateAppointment)
        {
            // await _auditService.PostAudit($"Set Appointment SurveyTypeId with AppointmentReq Id '{updateAppointment.RequestId + " To SurveyTypeId " + updateAppointment.SurveyTypeId}' By User ");
            var response = await _appointmentService.UpdateSurvTypeIdByReqId(updateAppointment);
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
