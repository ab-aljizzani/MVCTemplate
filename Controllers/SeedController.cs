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

        public SeedController(ISeedService seedService)
        {
            _seedService = seedService;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Seed()
        {
            return Ok(await _seedService.SeedAll());
        }
        [HttpPost]
        [Route("DeleteAll")]
        public async Task<ActionResult<string>> DeleteSeed()
        {
            return Ok(await _seedService.DeleteAll());
        }
    }
}
