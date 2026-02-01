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
            var response = await _appointmentService.UpdateAppointment(updateAppointment);
            // await _auditService.PostAudit($"Update Appointment with Id '{updateAppointment.Id + " To ApponitmentDate " + updateAppointment.ApponitmentDate + " And StartTime" + updateAppointment.AppointmentStartTime + " And EndTime " + updateAppointment.AppointmentEndTime}' By User ");
            await _auditService.PutAudit($"Update Appointment with Id '{updateAppointment.Id + " To ApponitmentDate " + updateAppointment.ApponitmentDate + " And StartTime" + updateAppointment.AppointmentStartTime + " And EndTime " + updateAppointment.AppointmentEndTime}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("EditIsAppIsSurvInserted")]
        public async Task<ActionResult<AppointmentDto>> EditIsAppIsSurvInserted(UpdateAppointmentIsSurveyInsertedDto updateAppointment)
        {
            var response = await _appointmentService.UpdateAppointmentIsSurvInserted(updateAppointment);
            await _auditService.PutAuditWithNoToken($"Update Appointment IsSurvInserted with Appointment Id '{updateAppointment.Id + " To IsSurvInserted " + updateAppointment.IsSurveyInserted}'", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditIsPersonShowup")]
        public async Task<ActionResult<AppointmentDto>> EditIsPersonShowup(UpdateIsPersonShowup updateAppointment)
        {
            var response = await _appointmentService.UpdateIsPersonShowUp(updateAppointment);
            await _auditService.PutAudit($"Update Appointment IsPersonShowUp with Appointment Id '{updateAppointment.Id + " To IsPersonShowUp " + updateAppointment.IsPersonShowUp}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditAppointmentReview")]
        public async Task<ActionResult<AppointmentDto>> EditAppointmentReview(UpdateAppointmentReviewDto updateAppointment)
        {
            var response = await _appointmentService.UpdateAppointmentReview(updateAppointment);
            await _auditService.PutAudit($"Update Appointment Review with Appointment Id '{updateAppointment.Id}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditAppointmentDoctorReview")]
        public async Task<ActionResult<AppointmentDto>> EditAppointmentDoctorReview(UpdateAppointmentDoctorReviewDto updateAppointment)
        {
            var response = await _appointmentService.UpdateAppointmentDoctorReview(updateAppointment);
            await _auditService.PutAudit($"Update Appointment Doctor Review with Appointment Id '{updateAppointment.Id + " To Review " + updateAppointment.AppointmentDoctorReview}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditSurvTypeIdByReqId")]
        public async Task<ActionResult<AppointmentDto>> EditSurvTypeIdByReqId(UpdateAppointmentSurveyTypeIdDto updateAppointment)
        {
            var response = await _appointmentService.UpdateSurvTypeIdByReqId(updateAppointment);
            await _auditService.PutAudit($"Set Appointment SurveyTypeId with Appointment Id '{updateAppointment.Id + " To SurveyTypeId " + updateAppointment.SurveyTypeId}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditAppointmentPortalUser")]
        public async Task<ActionResult<AppointmentDto>> EditAppointmentPortalUser(UpdateAppointmentPortalUserIdDto updateAppointment)
        {
            var response = await _appointmentService.UpdateAppointmentPortalId(updateAppointment);
            await _auditService.PutAudit($"Aupdate All Appointment Ids With PortalUserid '{updateAppointment.FromPortalUserId + " To PortalUserId" + updateAppointment.ToPortalUserId}' By User ", response.OldData);
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
