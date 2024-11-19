using ClinicApi.Dtos.SurveyDto.Get;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.SurveyDto.Update;
using ClinicApi.Services.Survey;
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
        private readonly ISurveyService _surveyService;

        public SurveyQuestionController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSurveyQuestionDto>>> GetAll()
        {
            return Ok(await _surveyService.GetAllSurveyQuestion());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetSurveyQuestionDto>>> GetSurveyById(int id)
        {
            return Ok(await _surveyService.GetSurveyQuestionByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertSurveyQuestionDto>>> AddnewSurveyQuestion(InsertSurveyQuestionDto newSurveyQuestion)
        {
            return Ok(await _surveyService.AddNewSurveyQuestion(newSurveyQuestion));
        }
        [HttpPut]
        public async Task<ActionResult<UpdateSurveyQuestionDto>> UpdateSurveyQuestion(UpdateSurveyQuestionDto updateSurveyQuestion)
        {
            var response = await _surveyService.UpdateSurveyQuestion(updateSurveyQuestion);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetSurveyQuestionDto>> DeleteSurveyQuestion(int id)
        {
            return Ok(await _surveyService.DeleteSurveyQuestion(id));
        }
    }
}
