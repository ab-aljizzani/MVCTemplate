using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.DashboardUserDto;
using ClinicApi.Dtos.DashboardUserDto.Insert;
using ClinicApi.Dtos.DashboardUserDto.Update;
using ClinicApi.Models.Reponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardUserController : ControllerBase
    {
        // private readonly IAuthRepositery _authRepo;
        // private readonly IMapper _mapper;
        // public DashboardUserController(IAuthRepositery authRepo, IMapper mapper)
        // {
        //     _authRepo = authRepo;
        //     _mapper = mapper;
        // }
        // [HttpGet]
        // public async Task<ActionResult<List<DashboardUserDto>>> DashboardGetAll()
        // {
        //     return Ok(await _authRepo.DashboardGetAll());
        // }
        // [HttpGet]
        // [Route("DashboardGetAllByEntityId")]
        // public async Task<ActionResult<List<DashboardUserDto>>> DashboardGetAllByEntityId(int id)
        // {
        //     return Ok(await _authRepo.DashboardGetAllByEntityId(id));
        // }
        // [HttpGet]
        // [Route("DashboardGetAllByUserType")]
        // public async Task<ActionResult<List<DashboardUserDto>>> DashboardGetAllByUserType(string type)
        // {
        //     return Ok(await _authRepo.DashboardGetAllByUserType(type));
        // }
        // [HttpGet("{id}")]
        // public async Task<ActionResult<List<DashboardUserDto>>> DashboardGetUserByID(int id)
        // {
        //     return Ok(await _authRepo.DashboardGetUserByID(id));
        // }
        // [HttpPost("DashboardLogin")]
        // public async Task<ActionResult<ServiceResponse<int>>> DashboardLogin(DashboardLoginDto request)
        // {
        //     var response = await _authRepo.DashboardLogin(request.Username, request.Password);
        //     if (!response.Success)
        //     {
        //         return BadRequest(response);
        //     }
        //     return Ok(response.Data);
        // }
        // [HttpPost]
        // public async Task<ActionResult<ServiceResponse<int>>> DashboardRegister(InsertDashboardUserDto request)
        // {
        //     // var user = _mapper.Map<Dashboard>(request);
        //     var response = await _authRepo.DashboardRegister(request, request.Password);
        //     if (!response.Success)
        //     {
        //         return BadRequest(response);
        //     }
        //     return Ok(response);
        // }
        // [HttpPut]
        // public async Task<ActionResult<UpdateDashboardUserDto>> DashboardUpdateUser(UpdateDashboardUserDto updateDashboardUser)
        // {
        //     var response = await _authRepo.DashboardUpdateUser(updateDashboardUser);
        //     if (response.Success == false)
        //         return NotFound(response);
        //     return Ok(response);
        // }
        // [HttpPut]
        // [Route("DashboardPasswordExpire")]
        // public async Task<ActionResult<UpdateDashboardUserDto>> DashboardPasswordExpire(DashboardPasswordExpireUpdateDto updateDashboardPassword)
        // {
        //     var response = await _authRepo.DashboardPasswordExpireUpdate(updateDashboardPassword);
        //     if (response.Success == false)
        //         return NotFound(response);
        //     return Ok(response);
        // }
        // [HttpPut]
        // [Route("DashboardPasswordInitial")]
        // public async Task<ActionResult<UpdateDashboardUserDto>> DashboardPasswordInitial(DashboardPasswordInitialDto updateDashboardPassword)
        // {
        //     var response = await _authRepo.DashboardPasswordInitialUpdate(updateDashboardPassword);
        //     if (response.Success == false)
        //         return NotFound(response);
        //     return Ok(response);
        // }
        // [HttpPut]
        // [Route("DashboardUserPhone")]
        // public async Task<ActionResult<UpdateDashboardUserDto>> DashboardUpdateUserPhone(UpdateDashboardUserPhoneDto updateDashboardPhone)
        // {
        //     var response = await _authRepo.DashboardUpdateUserPhone(updateDashboardPhone);
        //     if (response.Success == false)
        //         return NotFound(response);
        //     return Ok(response);
        // }

    }
}
