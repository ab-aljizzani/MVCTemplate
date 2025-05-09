using ClinicApi.Data;
using ClinicApi.Services.Seed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ISeedService _seedService;
        private readonly TokenRoles _token;

        public SeedController(ISeedService seedService, TokenRoles token)
        {
            _seedService = seedService;
            _token = token;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Seed()
        {
            return Ok(await _seedService.SeedAll());
        }
        [HttpPost]
        [Route("SeedEntityDept")]
        public async Task<ActionResult<string>> SeedEntityDept()
        {
            return Ok(await _seedService.SeedEntityDept());
        }
        [HttpPost]
        [Authorize]
        [Route("DeleteAll")]
        public async Task<ActionResult<string>> DeleteSeed()
        {
            var role = _token.GetRoleToken("Role");
            if (role == "SuperAdmin")
                return Ok(await _seedService.DeleteAll());
            else
                return NotFound();
        }
    }
}
