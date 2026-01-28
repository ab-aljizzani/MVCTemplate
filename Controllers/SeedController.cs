using ClinicApi.Data;
using ClinicApi.Services;
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
        private readonly IAuditService _auditService;

        public SeedController(ISeedService seedService, TokenRoles token, IAuditService auditService)
        {
            _seedService = seedService;
            _token = token;
            _auditService = auditService;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Seed()
        {
            await _auditService.PostAuditWuthNoToken("Seed All Data In Seed Service", "Seed");
            return Ok(await _seedService.SeedAll());
        }
        [HttpPost]
        [Route("SeedEntityDept")]
        public async Task<ActionResult<string>> SeedEntityDept()
        {
            await _auditService.PostAuditWuthNoToken("Seed Entity And Department Data In SeedEntityDept Service", "Seed");
            return Ok(await _seedService.SeedEntityDept());
        }
        [HttpPost]
        [Authorize]
        [Route("DeleteAll")]
        public async Task<ActionResult<string>> DeleteSeed()
        {
            var role = _token.GetRoleToken("Role");
            if (role == "SuperAdmin")
            {
                await _auditService.PostAuditWuthNoToken("Delete All Data In SeedDelete Service", "Seed");
                return Ok(await _seedService.DeleteAll());
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Authorize]
        [Route("DeleteDatabaseWithBackup")]
        public async Task<ActionResult<string>> DeleteDatabaseWithBackup()
        {
            var role = _token.GetRoleToken("Role");
            if (role == "SuperAdmin")
            {
                await _auditService.PostAuditWuthNoToken("Delete All Database And Generate Backup File ", "Seed");
                return Ok(await _seedService.BackupAndDeleteDatabase());
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Authorize]
        [Route("BackupDatabase")]
        public async Task<ActionResult<string>> BackupDatabase()
        {
            var role = _token.GetRoleToken("Role");
            if (role == "SuperAdmin")
            {
                await _auditService.PostAuditWuthNoToken("Backup Database Service", "Seed");
                return Ok(await _seedService.BackupDatabaseOnly());
            }
            else
                return NotFound();
        }
    }
}
