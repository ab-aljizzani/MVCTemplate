using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.SurveyDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.Survey;
using ClinicApi.ViewModel.Survey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyQuestionController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ISurveyService _surveyService;

        public SurveyQuestionController(IAuditService auditService, ISurveyService surveyService)
        {
            _auditService = auditService;
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSurveyQuestionDto>>> GetAll()
        {
            await _auditService.PostAudit("View All SurveyQuestion For User");
            return Ok(await _surveyService.GetAllSurveyQuestion());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetSurveyQuestionDto>>> GetSurveyById(int id)
        {
            await _auditService.PostAudit($"View Single SurveyQuestion By Id With Id Number '{id}' For User");
            return Ok(await _surveyService.GetSurveyQuestionByID(id));
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetSurveyBySurvTypeId")]
        public async Task<ActionResult<List<GetSurveyQesAnswerDto>>> GetSurveyBySurvTypeId(int id)
        {
            await _auditService.PostAuditWuthNoToken($"View All SurveyQuestion By SurveyTypeId With SurveyTypeId Number '{id}'");
            return Ok(await _surveyService.GetSurveyQuestionBySurvTypeId(id));
        }
        [HttpGet]
        [Route("GetSurveyQuestionAnswer")]
        public async Task<ActionResult<List<GetSurveyQesAnswerDto>>> GetSurveyQuestionAnswer(int id)
        {
            await _auditService.PostAudit($"View Single SurveyQuestion By AnswerId With AnswerId Number '{id}' For User");
            return Ok(await _surveyService.GetSurveyQuestionAnswer(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertSurveyQuestionDto>>> AddnewSurveyQuestion(InsertSurveyQuestionDto newSurveyQuestion)
        {
            await _auditService.PostAudit($"Insert SurveyQuestion '{newSurveyQuestion.Id + "with Ques" + newSurveyQuestion.Question}' By User ");
            return Ok(await _surveyService.AddNewSurveyQuestion(newSurveyQuestion));
        }
        [HttpPost]
        [Route("EditSurveyQuestion")]
        public async Task<ActionResult<UpdateSurveyQuestionDto>> UpdateSurveyQuestion(UpdateSurveyQuestionDto updateSurveyQuestion)
        {
            await _auditService.PostAudit($"Update SurveyQuestion For '{updateSurveyQuestion.Id + " To Ques " + updateSurveyQuestion.Question}' By User ");
            var response = await _surveyService.UpdateSurveyQuestion(updateSurveyQuestion);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetSurveyQuestionDto>> DeleteSurveyQuestion(int id)
        // {
        //     return Ok(await _surveyService.DeleteSurveyQuestion(id));
        // }
    }
}
