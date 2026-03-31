using ClinicApi.Dtos.RequestDto.Get;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RequestDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IRequestService _requestService;

        public RequestController(IAuditService auditService, IRequestService requestService)
        {
            _auditService = auditService;
            _requestService = requestService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetRequestDto>>> Get()
        {
            // await _auditService.PostAudit("View All Request For User");
            return Ok(await _requestService.GetAllRequest());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetSingle(int id)
        {
            await _auditService.PostAudit($"View Single Request By Id With Id Number '{id}' For User");
            return Ok(await _requestService.GetRequestByID(id));
        }
        [HttpGet]
        [Route("GetRequestsStatistics")]
        public async Task<ActionResult<object>> GetRequestsStatistics()
        {
            await _auditService.PostAudit($"View Requests Statistics For User");
            return Ok(await _requestService.GetRequestsStatistics());
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetByPersonId")]
        public async Task<ActionResult<GetRequestDto>> GetByPersonId(int id)
        {
            await _auditService.PostAuditWuthNoToken($"View Single Request By PersonId With PersonId Number '{id}'", id.ToString());
            return Ok(await _requestService.GetRequestByPersonId(id));
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetByPersonNationalId")]
        public async Task<ActionResult<GetPersonRisckLevelDto>> GetByPersonNationalId(int nationalId)
        {
            await _auditService.PostAuditWuthNoToken($"View Single Request By PersonNationalId With NationalId Number '{nationalId}'", nationalId.ToString());
            return Ok(await _requestService.GetRequestByPersonNationalId(nationalId));
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetRequestByPersonIdAndReqId")]
        public async Task<ActionResult<GetRequestDto>> GetRequestByPersonIdAndReqId(int id, int reqId)
        {
            await _auditService.PostAuditWuthNoToken($"View Single Request By PersonId And RequestId With Id's Numbera '{id + " " + reqId}'", id.ToString());
            return Ok(await _requestService.GetRequestByPersonIdAndReqId(id, reqId));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertRequestDto>>> AddNewRequest(InsertRequestDto newRequest)
        {
            await _auditService.PostAudit($"Insert Request With Id '{newRequest.Id + " With PersonId " + newRequest.PersonId}' By User ");
            return Ok(await _requestService.AddNewRequest(newRequest));
        }
        [HttpPost]
        [Route("EditRequest")]
        public async Task<ActionResult<UpdateRequestDto>> UpdateRequest(UpdateRequestDto updateRequest)
        {
            var response = await _requestService.UpdateRequest(updateRequest);
            await _auditService.PutAudit($"Update Request With ReqId '{updateRequest.Id + " To RequestStatusId " + updateRequest.RequestStatusId}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateAppsentReason")]
        public async Task<ActionResult<UpdateRequestAppsentReasonDto>> UpdateRequestAppsentReason(UpdateRequestAppsentReasonDto updateRequest)
        {
            var response = await _requestService.UpdateRequestAppsentReason(updateRequest);
            await _auditService.PutAudit($"Update AppsentReason With ReqId '{updateRequest.Id + " To " + updateRequest.AppsentReason}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateReqStatusId")]
        public async Task<ActionResult<UpdateRequestStatusIdDto>> UpdateReqStatusId(UpdateRequestStatusIdDto updateRequest)
        {
            var response = await _requestService.UpdateRequestStatusId(updateRequest);
            await _auditService.PutAudit($"Update UpdateReqStatusId With ReqId '{updateRequest.Id + " And reqStatusId To" + updateRequest.RequestStatusId}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateReqShowUp")]
        public async Task<ActionResult<UpdateRequestStatusIdDto>> UpdateReqShowUp(UpdateRequestShowupDto updateRequest)
        {
            var response = await _requestService.UpdateRequestShowUp(updateRequest);
            await _auditService.PutAudit($"Update UpdateReqShowUp With ReqId '{updateRequest.Id + " And IsPersonShowUp To" + updateRequest.IsPersonShowUp}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateReqSurveyInserted")]
        public async Task<ActionResult<UpdateRequestStatusIdDto>> UpdateReqSurveyInserted(UpdateRequestSurveyInsertedDto updateRequest)
        {
            var response = await _requestService.UpdateRequesIsSurveyInserted(updateRequest);
            await _auditService.PutAudit($"Update UpdateReqSurveyInserted With ReqId '{updateRequest.Id + " And reqSurveyInserted To" + updateRequest.IsSurveyInserted}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateReqAppointmentId")]
        public async Task<ActionResult<UpdateReqAppointmentIdDto>> UpdateReqAppointmentId(UpdateReqAppointmentIdDto updateRequest)
        {
            var response = await _requestService.UpdateReqAppointmentId(updateRequest);
            await _auditService.PutAudit($"Update UpdateReqAppointmentId With ReqId '{updateRequest.Id + " And AppointmentId To" + updateRequest.AppointmentId}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetRequestDto>> DeleteRequest(int id)
        // {
        //     return Ok(await _requestService.DeleteRequest(id));
        // }
    }
}
