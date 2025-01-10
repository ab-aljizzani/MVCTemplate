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
    public class SurveyAnswerController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ISurveyService _surveyService;

        public SurveyAnswerController(IAuditService auditService, ISurveyService surveyService)
        {
            _auditService = auditService;
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSurveyAnswerDto>>> GetAll()
        {
            await _auditService.PostAudit("View All SurveyAnswer For User");
            return Ok(await _surveyService.GetAllSurveyAnswer());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetSurveyAnswerDto>>> GetSurveyById(int id)
        {
            await _auditService.PostAudit($"View Single SurveyAnswer By Id With Id Number '{id}' For User");
            return Ok(await _surveyService.GetSurveyAnswerByID(id));
        }
        [HttpGet]
        [Route("GetSurveyByAnswetType")]
        public async Task<ActionResult<List<GetSurveyAnswerDto>>> GetSurveyByAnswetType(int id)
        {
            await _auditService.PostAudit($"View Single SurveyAnswer By AnswerTypeId With TypeId Number '{id}' For User");
            return Ok(await _surveyService.GetSurveyAnswerByAnswerType(id));
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("GetSurveyAnswerPointByID")]
        public async Task<ActionResult<List<GetSurveyAnswerDto>>> GetSurveyAnswerPointByID(int id)
        {
            await _auditService.PostAuditWuthNoToken($"View Single SurveyAnswerPoints By AnswerId With Id Number '{id}' ");
            return Ok(await _surveyService.GetSurveyAnswerPointByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertSurveyAnswerDto>>> AddnewSurveyAnswer(InsertSurveyAnswerDto newSurveyAnswer)
        {
            await _auditService.PostAudit($"Insert SurveyAnswer '{newSurveyAnswer.Answer + "For QusId " + newSurveyAnswer.SurveyQuestionId}' By User ");
            return Ok(await _surveyService.AddNewSurveyAnswer(newSurveyAnswer));
        }
        [HttpPost]
        [Route("Edit/SurveyAnswer")]
        public async Task<ActionResult<UpdateSurveyAnswerDto>> UpdateSurveyAnswer(UpdateSurveyAnswerDto updateSurveyAnswer)
        {
            await _auditService.PostAudit($"Update SurveyAnswer For '{updateSurveyAnswer.Id + " To Answer " + updateSurveyAnswer.Answer}' By User ");
            var response = await _surveyService.UpdateSurveyAnswer(updateSurveyAnswer);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetSurveyAnswerDto>> DeleteSurveyAnswer(int id)
        // {
        //     return Ok(await _surveyService.DeleteSurveyAnswer(id));
        // }
    }
}
