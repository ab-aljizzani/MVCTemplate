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
    public class PerscriptionController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IAppointmentService _appointmentService;

        public PerscriptionController(IAuditService auditService, IAppointmentService appointmentService)
        {
            _auditService = auditService;
            _appointmentService = appointmentService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PerscritionDto>>> GetAllPerscription()
        {
            await _auditService.PostAudit("View All Perscription For User");
            return Ok(await _appointmentService.GetAllPerscrition());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PerscritionDto>>> GetPerscriptionById(int id)
        {
            await _auditService.PostAudit($"View Single Perscription By Id '{id}' For User");
            return Ok(await _appointmentService.GetPerscritionByID(id));
        }
        [HttpGet]
        [Route("GetPerscriptionByAppId")]
        public async Task<ActionResult<List<object>>> GetPerscriptionByAppId(int id)
        {
            await _auditService.PostAudit($"View Single Perscription By Appointment Id '{id}' For User");
            return Ok(await _appointmentService.GetPerscritionByAppID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<PerscritionDto>>> AddnewPerscription(InsertPerscriptionDto insertPerscriptionDto)
        {
            await _auditService.PostAudit($"Insert NewPerscription With Id '{insertPerscriptionDto.Id + " PerscriptionName " + insertPerscriptionDto.PerscriptionName} By User ");
            return Ok(await _appointmentService.AddNewPerscrition(insertPerscriptionDto));
        }
        [HttpPost]
        [Route("EditPerscription")]
        public async Task<ActionResult<AppointmentStatusDto>> UpdatePerscription(UpdatePerscriptionDto updatePerscriptionDto)
        {
            await _auditService.PostAudit($"Update Perscription with Id '{updatePerscriptionDto.Id + " PerscriptionName " + updatePerscriptionDto.PerscriptionName} By User ");
            var response = await _appointmentService.UpdatePerscrition(updatePerscriptionDto);
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
