using ClinicApi.Dtos.RiskLevelDto.Get;
using ClinicApi.Dtos.RiskLevelDto.Insert;
using ClinicApi.Dtos.RiskLevelDto.Update;
using ClinicApi.Services;
using ClinicApi.Services.RiskLevelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RiskLevelController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IRiskLevelService _riskLevel;

        public RiskLevelController(IAuditService auditService, IRiskLevelService riskLevel)
        {
            _auditService = auditService;
            _riskLevel = riskLevel;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetRiskLevelDto>>> GetAllRiskLevel()
        {
            await _auditService.PostAudit("View All RiskLevel For User");
            return Ok(await _riskLevel.GetAllRisk());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetRiskLevelDto>>> GetRiskLevelById(int id)
        {
            await _auditService.PostAudit($"View Single RiskLevel By Id With Id Number '{id}' For User");
            return Ok(await _riskLevel.GetRiskByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<GetRiskLevelDto>>> AddnewRiskLevel(InsertRiskLevelDto newRiskLevel)
        {
            await _auditService.PostAudit($"Insert RiskLevel '{newRiskLevel.Id + " " + newRiskLevel.Risk}' By User ");
            return Ok(await _riskLevel.AddNewRisk(newRiskLevel));
        }
        [HttpPost]
        [Route("EditRiskLevel")]
        public async Task<ActionResult<GetRiskLevelDto>> UpdateRiskLevel(UpdateRiskLevelDto updateRiskLevel)
        {
            var response = await _riskLevel.UpdateRisk(updateRiskLevel);
            await _auditService.PutAudit($"Update RiskLevel For '{updateRiskLevel.Id + " To " + updateRiskLevel.Risk}' By User ", response.OldData);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<GetRiskLevelDto>> DeleteRiskLevel(int id)
        // {
        //     return Ok(await _riskLevel.DeleteRisk(id));
        // }
    }
}
