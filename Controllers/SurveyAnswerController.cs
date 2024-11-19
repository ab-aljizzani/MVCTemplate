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
    public class SurveyAnswerController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyAnswerController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetSurveyAnswerDto>>> GetAll()
        {
            return Ok(await _surveyService.GetAllSurveyAnswer());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetSurveyAnswerDto>>> GetSurveyById(int id)
        {
            return Ok(await _surveyService.GetSurveyAnswerByID(id));
        }
        [HttpGet]
        [Route("GetSurveyByAnswetType")]
        public async Task<ActionResult<List<GetSurveyAnswerDto>>> GetSurveyByAnswetType(int id)
        {
            return Ok(await _surveyService.GetSurveyAnswerByAnswerType(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertSurveyAnswerDto>>> AddnewSurveyAnswer(InsertSurveyAnswerDto newSurveyAnswer)
        {
            return Ok(await _surveyService.AddNewSurveyAnswer(newSurveyAnswer));
        }
        [HttpPut]
        public async Task<ActionResult<UpdateSurveyAnswerDto>> UpdateSurveyAnswer(UpdateSurveyAnswerDto updateSurveyAnswer)
        {
            var response = await _surveyService.UpdateSurveyAnswer(updateSurveyAnswer);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetSurveyAnswerDto>> DeleteSurveyAnswer(int id)
        {
            return Ok(await _surveyService.DeleteSurveyAnswer(id));
        }
    }
}
