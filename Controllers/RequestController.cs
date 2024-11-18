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
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetRequestDto>>> Get()
        {
            return Ok(await _requestService.GetAllRequest());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRequestDto>> GetSingle(int id)
        {
            return Ok(await _requestService.GetRequestByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<InsertRequestDto>>> AddNewRequest(InsertRequestDto newRequest)
        {
            return Ok(await _requestService.AddNewRequest(newRequest));
        }
        [HttpPut]
        public async Task<ActionResult<UpdateRequestDto>> UpdateRequest(UpdateRequestDto updateRequest)
        {
            var response = await _requestService.UpdateRequest(updateRequest);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GetRequestDto>> DeleteRequest(int id)
        {
            return Ok(await _requestService.DeleteRequest(id));
        }
    }
}
