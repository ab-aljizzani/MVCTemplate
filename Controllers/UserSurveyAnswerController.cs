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
    public class UserSurveyAnswerController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public UserSurveyAnswerController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetUserSurveyAnswerDto>>> GetAll()
        {
            return Ok(await _surveyService.GetAllUserSurveyAnswer());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetUserSurveyAnswerDto>>> GetSurveyById(int id)
        {
            return Ok(await _surveyService.GetUserSurveyAnswerByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertUserSurveyAnswerDto>>> AddnewUserSurvey(InsertUserSurveyAnswerDto newUserSurvey)
        {
            return Ok(await _surveyService.AddNewUserSurveyAnswer(newUserSurvey));
        }
        [HttpPost]
        [Route("EditUserSurveyAnswer")]
        public async Task<ActionResult<UpdateUserSurveyAnswerDto>> UpdateUserSurvey(UpdateUserSurveyAnswerDto updateUserSurvey)
        {
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
