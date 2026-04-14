using AutoMapper;
using MVCTemplate.Data;
using MVCTemplate.Dtos.PortalUserDto;
using MVCTemplate.Dtos.PortalUserModelDto;
using MVCTemplate.Dtos.PortalUserModelDto.Insert;
using MVCTemplate.Dtos.PortalUserModelDto.Update;
using MVCTemplate.Models.PortalUser;
using MVCTemplate.Models.Reponse;
using MVCTemplate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCTemplate.Controllers
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
        [HttpGet]
        [Route("GetSingleByNationalId")]
        public async Task<ActionResult<List<PortalUserDto>>> GetSingleByNationalId(string id)
        {
            // await _auditService.PostAudit($"View Single PortalUser By Id With Id Number '{id}' For User");
            return Ok(await _authRepo.GetUserByNationalId(id));
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.UserPass);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            await _auditService.PostAuditWuthNoToken($"User With NatuinalId Num '{request.Username}' is LoggedIn", request.Username);
            return Ok(response.Data);
        }
        [AllowAnonymous]
        [HttpPost("IamLogin")]
        public async Task<ActionResult<ServiceResponse<int>>> IamLogin(ExsistUserDto request)
        {
            var response = await _authRepo.IamLogin(request.Username);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            await _auditService.PostAuditWuthNoToken($"User With NatuinalId Num '{request.Username}' is LoggedIn", request.Username);
            return Ok(response.Data);
        }
       
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<int>>> Register(InsertPortalUserDto request)
        {
            await _auditService.PostAudit($"Insert PortalUser '{request.Id + " With NationalId " + request.NationalId}' By User ");
            // var user = _mapper.Map<PortalUser>(request);
            var response = await _authRepo.Register(request, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("IamRegister")]
        public async Task<ActionResult<ServiceResponse<int>>> IamRegister(InsertPortalUserDto request)
        {
            await _auditService.PostAuditWuthNoToken($"Insert PortalUser '{request.Id + " With NationalId " + request.NationalId}' By User ", request.NationalId);
            // var user = _mapper.Map<PortalUser>(request);
            var response = await _authRepo.IamRegister(request);
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
            var response = await _authRepo.UpdatePortalUser(updatePortalUser);
            await _auditService.PutAudit("Update PortalUser Password By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
       
        [HttpPost]
        [Route("UpdateUserRole")]
        public async Task<ActionResult<UpdatePortalUserRoleDto>> UpdateUserRole(UpdatePortalUserRoleDto updatePortalUserRole)
        {
            var response = await _authRepo.UpdateUserRole(updatePortalUserRole);
            await _auditService.PutAudit($"Update PortalUser Role With PortalUserId '{updatePortalUserRole.Id + " To RoleId " + updatePortalUserRole.RoleId}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("UserExists")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> UserExists(ExsistUserDto userName)
        {
            // await _auditService.PostAudit($"Update PortalUser Role With PortalUserId '{updatePortalUserRole.Id + " To RoleId " + updatePortalUserRole.RoleId}' By User ");
            var response = await _authRepo.UserExists(userName.Username);
            return Ok(response);
        }
    }
}
