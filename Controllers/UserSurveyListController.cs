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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserSurveyListController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ISurveyService _surveyService;

        public UserSurveyListController(IAuditService auditService, ISurveyService surveyService)
        {
            _auditService = auditService;
            _surveyService = surveyService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetUserSurveyListDto>>> GetAll()
        {
            await _auditService.PostAudit("View All UserSurveyList For User");
            return Ok(await _surveyService.GetAllUserSurveyList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetUserSurveyListDto>>> GetUserSurveyListById(int id)
        {
            await _auditService.PostAudit($"View Single UserSurveyList By Id With Id Number '{id}' For User");
            return Ok(await _surveyService.GetUserSurveyListByID(id));
        }
        [HttpGet]
        [Route("GetUserSurveyListByReqId")]
        // [AllowAnonymous]
        public async Task<ActionResult<List<GetUserSurveyListDto>>> GetUserSurveyListByReqId(int id)
        {
            await _auditService.PostAudit($"View Single UserSurveyList By ReqId With Number '{id}' For User");
            return Ok(await _surveyService.GetUserSurveyListByReqId(id));
        }
        [HttpGet]
        [Route("GetUserSurveyListScore")]
        // [AllowAnonymous]
        public async Task<ActionResult<GetUserSurveyScoreDto>> GetUserSurveyListScore(int appId, int reqId, int survTypeId)
        {
            await _auditService.PostAudit($"View Single UserSurveyList By AppId & ReqId & survTypeId With Number '{appId + ' ' + reqId + ' ' + survTypeId}' For User");
            return Ok(await _surveyService.GetUserSurveyListScore(appId, reqId, survTypeId));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertUserSurveyListDto>>> AddnewUserSurveyList(InsertUserSurveyListDto newSurvey)
        {
            await _auditService.PostAudit("Insert UserSurveyList By User ");
            return Ok(await _surveyService.AddNewUserSurveyList(newSurvey));
        }
        [HttpPost]
        [Route("EditUserSurveyList")]
        public async Task<ActionResult<UpdateUserSurveyListDto>> UpdateUserSurveyList(UpdateUserSurveyListDto updateSurvey)
        {
            await _auditService.PostAudit($"Update UserSurveyList For '{updateSurvey}' By User ");
            var response = await _surveyService.UpdateUserSurveyList(updateSurvey);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditUserSurveyListScoreAndInserted")]
        public async Task<ActionResult<UpdateUserSurveyListScoreAndInserted>> EditUserSurveyListScoreAndInserted(UpdateUserSurveyListScoreAndInserted updateSurvey)
        {
            await _auditService.PostAudit($"Update UserSurveyList For '{updateSurvey}' By User ");
            var response = await _surveyService.UpdateUserSurveyListScoreAndInserted(updateSurvey);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetUserSurveyListDto>> DeleteUserSurveyList(int id)
        // {
        //     await _auditService.PostAudit($"Delete UserSurveyList With Id Number '{id}' By User ");
        //     return Ok(await _surveyService.DeleteUserSurveyList(id));
        // }
    }
}
