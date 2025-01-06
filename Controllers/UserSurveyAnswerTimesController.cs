using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Services;
using ClinicApi.Services.Survey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserSurveyAnswerTimesController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ISurveyService _surveyService;

        public UserSurveyAnswerTimesController(IAuditService auditService, ISurveyService surveyService)
        {
            _auditService = auditService;
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetUserSurveyAnswerTimeDto>>> GetAll()
        {
            await _auditService.PostAudit("View All UserSurveyAnswerTime For User");
            return Ok(await _surveyService.GetAllUserSurveyAnswerTime());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetUserSurveyAnswerTimeDto>>> GetSurveyById(int id)
        {
            await _auditService.PostAudit($"View UserSurveyAnswerTime By AppointmentId With AppointmentId Number '{id}' For User");
            return Ok(await _surveyService.GetUserSurveyAnswerTimeByAppointId(id));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<List<GetUserSurveyAnswerTimeDto>>> AddnewUserSurvey(InsertUserSurveyAnswerTimeDto newUserSurveyTimes)
        {
            await _auditService.PostAuditWuthNoToken($"Insert UserSurveyAnswer For Appointment '{newUserSurveyTimes.AppointmentId + " With AnswerId " + newUserSurveyTimes.SurveyAnswerId + "For QuesId " + newUserSurveyTimes.SurveyQuestionId}' ");
            return Ok(await _surveyService.AddNewUserSurveyAnswerTime(newUserSurveyTimes));
        }
    }
}
