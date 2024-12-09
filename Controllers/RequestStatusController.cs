using ClinicApi.Dtos.RequestDto.Get;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RequestDto.Update;
using ClinicApi.Services.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestStatusController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetRequestStatusDto>>> Get()
        {
            return Ok(await _requestService.GetAllRequestStatus());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRequestStatusDto>> GetSingle(int id)
        {
            return Ok(await _requestService.GetRequestStatusByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetRequestStatusDto>>> AddnewRequestStatus(InsertRequestStatusDto newRequest)
        {
            return Ok(await _requestService.AddNewRequestStatus(newRequest));
        }
        [HttpPost]
        [Route("EditRequestStatus")]
        public async Task<ActionResult<UpdateRequestStatusDto>> UpdateRequestStatus(UpdateRequestStatusDto updateRequest)
        {
            var response = await _requestService.UpdateRequestStatus(updateRequest);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetRequestStatusDto>> DeleteRequestStatus(int id)
        // {
        //     return Ok(await _requestService.DeleteRequestStatus(id));
        // }
    }
}
