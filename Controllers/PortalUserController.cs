using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.PortalUserModelDto.Insert;
using ClinicApi.Dtos.PortalUserModelDto.Update;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Reponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalUserController : ControllerBase
    {
        private readonly IAuthRepositery _authRepo;
        private readonly IMapper _mapper;

        public PortalUserController(IAuthRepositery authRepo, IMapper mapper)
        {
            _authRepo = authRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<PortalUserDto>>> GetAll()
        {
            return Ok(await _authRepo.GetAll());
        }
        [HttpGet]
        [Route("GetAllByEntityId")]
        public async Task<ActionResult<List<PortalUserDto>>> GetAllByEntityId(int id)
        {
            return Ok(await _authRepo.GetAllByEntityId(id));
        }
        [HttpGet]
        [Route("GetAllByUserType")]
        public async Task<ActionResult<List<PortalUserDto>>> GetAllByUserType(string type)
        {
            return Ok(await _authRepo.GetAllByUserType(type));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PortalUserDto>>> GetSingle(int id)
        {
            return Ok(await _authRepo.GetUserByID(id));
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response.Data);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> Register(InsertPortalUserDto request)
        {
            // var user = _mapper.Map<PortalUser>(request);
            var response = await _authRepo.Register(request, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<UpdatePortalUserDto>> UpdatePortalUser(UpdatePortalUserDto updatePortalUser)
        {
            var response = await _authRepo.UpdatePortalUser(updatePortalUser);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPut]
        [Route("PasswordExpire")]
        public async Task<ActionResult<UpdatePortalUserDto>> PasswordExpire(PasswordExpireUpdateDto updatePortalUserPassword)
        {
            var response = await _authRepo.PasswordExpireUpdate(updatePortalUserPassword);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPut]
        [Route("PasswordInitial")]
        public async Task<ActionResult<UpdatePortalUserDto>> PasswordInitial(PasswordInitialDto updatePortalUserPassword)
        {
            var response = await _authRepo.PasswordInitialUpdate(updatePortalUserPassword);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPut]
        [Route("UpdateUserPhone")]
        public async Task<ActionResult<UpdatePortalUserDto>> UpdateUserPhone(UpdatePortalUserPhoneDto updatePortalUserPhone)
        {
            var response = await _authRepo.UpdateUserPhone(updatePortalUserPhone);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
    }
}
