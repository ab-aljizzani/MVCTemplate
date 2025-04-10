using ClinicApi.Dtos.CountriesDto.Get;
using ClinicApi.Services;
using ClinicApi.Services.CountriesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly ICountriesService _countriesService;

        public CountriesController(IAuditService auditService, ICountriesService countriesService)
        {
            _auditService = auditService;
            _countriesService = countriesService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetCountrieDto>>> GetAllAppointment()
        {
            await _auditService.PostAudit("View All Countries For User");
            return Ok(await _countriesService.GetAll());
        }
    }
}
