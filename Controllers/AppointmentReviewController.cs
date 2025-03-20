using ClinicApi.Dtos.ApoointmentReviewDto.Get;
using ClinicApi.Dtos.ApoointmentReviewDto.Insert;
using ClinicApi.Dtos.ApoointmentReviewDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.AppointmentReviewServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentReviewController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IAppointmentReviewService _appointmentReview;
        public AppointmentReviewController(IAuditService auditService, IAppointmentReviewService appointmentReview)
        {
            _auditService = auditService;
            _appointmentReview = appointmentReview;

        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetAppointmentReviewDto>>> GetAllAppointment()
        {
            await _auditService.PostAudit("View All Appointments Review For User");
            return Ok(await _appointmentReview.GetAllAppointmentReview());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetAppointmentReviewDto>>> GetAppointmentReviewById(int id)
        {
            await _auditService.PostAudit($"View Single Appointment Review By Id '{id}' For User");
            return Ok(await _appointmentReview.GetAppointmentReviewByID(id));
        }
        [HttpGet]
        [Route("GetAppointmentReviewByAppointmentId")]
        public async Task<ActionResult<List<GetAppointmentReviewDto>>> GetAppointmentReviewByAppointmentId(int AppointmentId)
        {
            await _auditService.PostAudit($"View Appointment Reviews By Appointment Id '{AppointmentId}' For User");
            return Ok(await _appointmentReview.GetAppointmentReviewByAppointmentId(AppointmentId));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetAppointmentReviewDto>>> AddnewAppointmentReview(InsertAppointmentReviewDto insertAppointmentReviewDto)
        {
            await _auditService.PostAudit($"Insert NewAppointment Review With AppointmentId '{insertAppointmentReviewDto.AppointmentId + " ApponitmentReview " + insertAppointmentReviewDto.Review}' By User ");
            return Ok(await _appointmentReview.AddNewAppointmentReview(insertAppointmentReviewDto));
        }
        [HttpPost]
        [Route("EditAppointmentReview")]
        public async Task<ActionResult<GetAppointmentReviewDto>> UpdateAppointmentReview(UpdateAppointmentReview_Dto updateAppointment)
        {
            await _auditService.PostAudit($"Update Appointment Review with Id '{updateAppointment.Id + " To ApponitmentReview " + updateAppointment.Review}' By User ");
            var response = await _appointmentReview.UpdateAppointmentReview(updateAppointment);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<List<GetAppointmentReviewDto>>> DeleteAppointmentReview(int id)
        // {
        //     await _auditService.PostAudit($"Delete Appointment Review With Id '{id}' By User ");
        //     return Ok(await _appointmentReview.DeleteAppointmentReview(id));
        // }

    }
}
