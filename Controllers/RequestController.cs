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
        [AllowAnonymous]
        [HttpGet]
        [Route("GetByPersonId")]
        public async Task<ActionResult<GetRequestDto>> GetByPersonId(int id)
        {
            await _auditService.PostAuditWuthNoToken($"View Single Request By PersonId With PersonId Number '{id}'");
            return Ok(await _requestService.GetRequestByPersonId(id));
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetRequestByPersonIdAndReqId")]
        public async Task<ActionResult<GetRequestDto>> GetRequestByPersonIdAndReqId(int id, int reqId)
        {
            await _auditService.PostAuditWuthNoToken($"View Single Request By PersonId And RequestId With Id's Numbera '{id + " " + reqId}'");
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
            await _auditService.PostAudit($"Update Request With ReqId '{updateRequest.Id + " To RequestStatusId " + updateRequest.RequestStatusId}' By User ");
            var response = await _requestService.UpdateRequest(updateRequest);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateAppsentReason")]
        public async Task<ActionResult<UpdateRequestAppsentReasonDto>> UpdateRequestAppsentReason(UpdateRequestAppsentReasonDto updateRequest)
        {
            await _auditService.PostAudit($"Update AppsentReason With ReqId '{updateRequest.Id + " To " + updateRequest.AppsentReason}' By User ");
            var response = await _requestService.UpdateRequestAppsentReason(updateRequest);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateReqStatusId")]
        public async Task<ActionResult<UpdateRequestStatusIdDto>> UpdateReqStatusId(UpdateRequestStatusIdDto updateRequest)
        {
            await _auditService.PostAudit($"Update UpdateReqStatusId With ReqId '{updateRequest.Id + " And reqStatusId To" + updateRequest.RequestStatusId}' By User ");
            var response = await _requestService.UpdateRequestStatusId(updateRequest);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateReqSurveyInserted")]
        public async Task<ActionResult<UpdateRequestStatusIdDto>> UpdateReqSurveyInserted(UpdateRequestSurveyInsertedDto updateRequest)
        {
            await _auditService.PostAudit($"Update UpdateReqSurveyInserted With ReqId '{updateRequest.Id + " And reqSurveyInserted To" + updateRequest.IsSurveyInserted}' By User ");
            var response = await _requestService.UpdateRequesIsSurveyInserted(updateRequest);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateReqAppointmentId")]
        public async Task<ActionResult<UpdateReqAppointmentIdDto>> UpdateReqAppointmentId(UpdateReqAppointmentIdDto updateRequest)
        {
            await _auditService.PostAudit($"Update UpdateReqAppointmentId With ReqId '{updateRequest.Id + " And AppointmentId To" + updateRequest.AppointmentId}' By User ");
            var response = await _requestService.UpdateReqAppointmentId(updateRequest);
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
