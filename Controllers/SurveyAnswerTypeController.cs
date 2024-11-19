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
    public class SurveyAnswerTypeController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyAnswerTypeController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSurveyAnswerTypeDto>>> GetAll()
        {
            return Ok(await _surveyService.GetAllSurveyAnswerType());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetSurveyAnswerTypeDto>>> GetSurveyById(int id)
        {
            return Ok(await _surveyService.GetSurveyAnswerTypeByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertSurveyAnswerTypeDto>>> AddnewSurveyAnswerType(InsertSurveyAnswerTypeDto newSurveyAnswerType)
        {
            return Ok(await _surveyService.AddNewSurveyAnswerType(newSurveyAnswerType));
        }
        [HttpPut]
        public async Task<ActionResult<UpdateSurveyAnswerTypeDto>> UpdateSurveyAnswerType(UpdateSurveyAnswerTypeDto updateSurveyAnswerType)
        {
            var response = await _surveyService.UpdateSurveyAnswerType(updateSurveyAnswerType);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetSurveyAnswerTypeDto>> DeleteSurveyAnswerType(int id)
        {
            return Ok(await _surveyService.DeleteSurveyAnswer(id));
        }
    }
}
