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
        [HttpGet]
        [Route("CheckUserSurveyAnswerBySurveyTypeID")]
        public async Task<ActionResult<List<GetUserSurveyAnswerDto>>> CheckUserSurveyAnswerBySurveyTypeID(int id)
        {
            await _auditService.PostAudit($"Check If UserSurveyAnswer Has Answers Filtered By SurveyTypeId '{id}' For User");
            return Ok(await _surveyService.CheckUserSurveyAnswerBySurveyTypeID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertUserSurveyAnswerDto>>> AddnewUserSurvey(InsertUserSurveyAnswerDto newUserSurvey)
        {
            await _auditService.PostAudit($"Insert UserSurveyAnswer For PersonId '{newUserSurvey.PersonId + " With AnswerId " + newUserSurvey.SurveyAnswerId + "For QuesId " + newUserSurvey.SurveyQuestionId}' For User ");
            return Ok(await _surveyService.AddNewUserSurveyAnswer(newUserSurvey));
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("AddnewUserSurveyNoPortal")]
        public async Task<ActionResult<List<InsertUserSurveyAnswerNoPortalDto>>> AddnewUserSurveyNoPortal(InsertUserSurveyAnswerNoPortalDto newUserSurvey)
        {
            await _auditService.PostAuditWuthNoToken($"Insert UserSurveyAnswer For PersonId '{newUserSurvey.PersonId + " With AnswerId " + newUserSurvey.SurveyAnswerId + "For QuesId " + newUserSurvey.SurveyQuestionId}'  ", newUserSurvey.PersonId.ToString());
            return Ok(await _surveyService.AddNewUserSurveyAnswerNoPortal(newUserSurvey));
        }
        [HttpPost]
        [Route("EditUserSurveyAnswer")]
        public async Task<ActionResult<UpdateUserSurveyAnswerDto>> UpdateUserSurvey(UpdateUserSurveyAnswerDto updateUserSurvey)
        {
            var response = await _surveyService.UpdateUserSurveyAnswer(updateUserSurvey);
            await _auditService.PutAudit($"Update UserSurveyAnswer With Id '{updateUserSurvey.Id + " For PersonId " + updateUserSurvey.PersonId + " To AnsId " + updateUserSurvey.SurveyAnswerId + " For QuesId " + updateUserSurvey.SurveyQuestionId}' By User ", response.OldData);
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
