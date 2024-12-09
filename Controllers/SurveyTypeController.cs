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
    public class SurveyTypeController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ISurveyService _surveyService;

        public SurveyTypeController(IAuditService auditService, ISurveyService surveyService)
        {
            _auditService = auditService;
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSurveyTypeDto>>> GetAll()
        {
            await _auditService.PostAudit("View All SurveyType For User");
            return Ok(await _surveyService.GetAllSurvey());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetSurveyTypeDto>>> GetSurveyById(int id)
        {
            await _auditService.PostAudit($"View Single SurveyType By Id With Id Number '{id}' For User");
            return Ok(await _surveyService.GetSurveyByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertSurveyTypeDto>>> AddnewSurvey(InsertSurveyTypeDto newSurvey)
        {
            await _auditService.PostAudit("Insert SurveyType By User ");
            return Ok(await _surveyService.AddNewSurvey(newSurvey));
        }
        [HttpPost]
        [Route("EditSurveyType")]
        public async Task<ActionResult<UpdateSurveyTypeDto>> UpdateSurvey(UpdateSurveyTypeDto updateSurvey)
        {
            await _auditService.PostAudit($"Update SurveyType For '{updateSurvey}' By User ");
            var response = await _surveyService.UpdateSurvey(updateSurvey);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetSurveyTypeDto>> DeleteSurvey(int id)
        // {
        //     return Ok(await _surveyService.DeleteSurvey(id));
        // }
    }
}
