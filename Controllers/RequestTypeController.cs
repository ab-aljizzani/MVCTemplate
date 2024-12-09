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
    public class RequestTypeController : ControllerBase
    {
         private readonly IRequestService _requestService;

        public RequestTypeController(IRequestService requestService)
        {
            _requestService = requestService;
        }
         [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetRequestTypeDto>>> Get()
        {
            return Ok(await _requestService.GetAllRequestType());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRequestTypeDto>> GetSingle(int id)
        {
            return Ok(await _requestService.GetRequestTypeByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetRequestTypeDto>>> AddnewRequestType(InsertRequestTypeDto newRequest)
        {
            return Ok(await _requestService.AddNewRequestType(newRequest));
        }
        [HttpPost]
        [Route("EditRequestType")]
        public async Task<ActionResult<UpdateRequestTypeDto>> UpdateRequestType(UpdateRequestTypeDto updateRequest)
        {
            var response = await _requestService.UpdateRequestType(updateRequest);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetRequestTypeDto>> DeleteRequestType(int id)
        // {
        //     return Ok(await _requestService.DeleteRequestType(id));
        // }
    }
}
