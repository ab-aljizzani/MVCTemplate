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

        public PortalUserController(IAuthRepositery authRepo)
        {
            _authRepo = authRepo;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> Register(PortalUserDto request)
        {
            var response = await _authRepo.Register(new PortalUser
            {
                Username = request.Username,
                UserType = request.UserType,
                RoleId = request.RoleId,
                Email = request.Email,
                DateOfBirth = DateTime.Now,
                PhoneNumber = request.PhoneNumber,
                CreatedUser = DateTime.Now,
                LoginAttemp = request.LoginAttemp,
                UserExpires = request.UserExpires
            }, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
