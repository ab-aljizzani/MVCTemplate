using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.SurveyDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.Survey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserSurveyAnswerController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ISurveyService _surveyService;

        public UserSurveyAnswerController(IAuditService auditService, ISurveyService surveyService)
        {
            _auditService = auditService;
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetUserSurveyAnswerDto>>> GetAll()
        {
            await _auditService.PostAudit("View All UserSurveyAnswer For User");
            return Ok(await _surveyService.GetAllUserSurveyAnswer());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetUserSurveyAnswerDto>>> GetSurveyById(int id)
        {
            await _auditService.PostAudit($"View Single UserSurveyAnswer By RequestId With RequestId Number '{id}' For User");
            return Ok(await _surveyService.GetUserSurveyAnswerByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertUserSurveyAnswerDto>>> AddnewUserSurvey(InsertUserSurveyAnswerDto newUserSurvey)
        {
            await _auditService.PostAudit($"Insert UserSurveyAnswer For PersonId '{newUserSurvey.PersonId + " With AnswerId " + newUserSurvey.SurveyAnswerId + "For QuesId " + newUserSurvey.SurveyQuestionId}' By User ");
            return Ok(await _surveyService.AddNewUserSurveyAnswer(newUserSurvey));
        }
        [HttpPost]
        [Route("EditUserSurveyAnswer")]
        public async Task<ActionResult<UpdateUserSurveyAnswerDto>> UpdateUserSurvey(UpdateUserSurveyAnswerDto updateUserSurvey)
        {
            await _auditService.PostAudit($"Update UserSurveyAnswer With Id '{updateUserSurvey.Id + " For PersonId " + updateUserSurvey.PersonId + " To AnsId " + updateUserSurvey.SurveyAnswerId + " For QuesId " + updateUserSurvey.SurveyQuestionId}' By User ");
            var response = await _surveyService.UpdateUserSurveyAnswer(updateUserSurvey);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetUserSurveyAnswerDto>> DeleteUserSurvey(int id)
        // {
        //     return Ok(await _surveyService.DeleteUserSurveyAnswer(id));
        // }
    }
}
