using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.PortalUserDto;
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
        public async Task<ActionResult<ServiceResponse<int>>> Register(PortalUserDto request)
        {
            var user = _mapper.Map<PortalUser>(request);
            var response = await _authRepo.Register(user, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
