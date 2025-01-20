using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.PortalUserModelDto;
using ClinicApi.Dtos.PortalUserModelDto.Insert;
using ClinicApi.Dtos.PortalUserModelDto.Update;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Reponse;
using ClinicApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortalUserController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IAuthRepositery _authRepo;
        private readonly IMapper _mapper;

        public PortalUserController(IAuditService auditService, IAuthRepositery authRepo, IMapper mapper)
        {
            _auditService = auditService;
            _authRepo = authRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<PortalUserDto>>> GetAll()
        {
            // await _auditService.PostAudit("View All PortalUser For User");
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
            // await _auditService.PostAudit($"View Single PortalUser By UsetType With Type Number '{type}' For User");
            return Ok(await _authRepo.GetAllByUserType(type));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<PortalUserDto>>> GetSingle(int id)
        {
            // await _auditService.PostAudit($"View Single PortalUser By Id With Id Number '{id}' For User");
            return Ok(await _authRepo.GetUserByID(id));
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            await _auditService.PostAuditWuthNoToken($"User With NatuinalId Num '{request.Username}' is LoggedIn");
            return Ok(response.Data);
        }
        [AllowAnonymous]
        [HttpPost("PersonLogin")]
        public async Task<ActionResult<ServiceResponse<int>>> PersonLogin(PersonLoginDto request)
        {
            var response = await _authRepo.PersonLogin(request.Username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            await _auditService.PostAuditWuthNoToken($"User With NatuinalId Num '{request.Username}' is LoggedIn");
            return Ok(response.Data);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<int>>> Register(InsertPortalUserDto request)
        {
            // await _auditService.PostAudit($"Insert PortalUser '{request.Id + " With NationalId " + request.NationalId}' By User ");
            // var user = _mapper.Map<PortalUser>(request);
            var response = await _authRepo.Register(request, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("EditPassword")]
        public async Task<ActionResult<UpdatePortalUserDto>> UpdatePortalUser(UpdatePortalUserDto updatePortalUser)
        {
            await _auditService.PostAudit("Update PortalUser Password By User ");
            var response = await _authRepo.UpdatePortalUser(updatePortalUser);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("PasswordExpire")]
        public async Task<ActionResult<UpdatePortalUserDto>> PasswordExpire(PasswordExpireUpdateDto updatePortalUserPassword)
        {
            await _auditService.PostAudit("Update PortalUser PasswordExpire By User ");
            var response = await _authRepo.PasswordExpireUpdate(updatePortalUserPassword);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("PasswordInitial")]
        public async Task<ActionResult<UpdatePortalUserDto>> PasswordInitial(PasswordInitialDto updatePortalUserPassword)
        {
            await _auditService.PostAudit("Update PortalUser PasswordInitial By User ");
            var response = await _authRepo.PasswordInitialUpdate(updatePortalUserPassword);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateUserPhone")]
        public async Task<ActionResult<UpdatePortalUserDto>> UpdateUserPhone(UpdatePortalUserPhoneDto updatePortalUserPhone)
        {
            await _auditService.PostAudit($"Update PortalUser phone With PortalUserId '{updatePortalUserPhone.Id + " To " + updatePortalUserPhone.PhoneNumber}' By User ");
            var response = await _authRepo.UpdateUserPhone(updatePortalUserPhone);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UpdateUserRole")]
        public async Task<ActionResult<UpdatePortalUserRoleDto>> UpdateUserRole(UpdatePortalUserRoleDto updatePortalUserRole)
        {
            await _auditService.PostAudit($"Update PortalUser Role With PortalUserId '{updatePortalUserRole.Id + " To RoleId " + updatePortalUserRole.RoleId}' By User ");
            var response = await _authRepo.UpdateUserRole(updatePortalUserRole);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
    }
}
