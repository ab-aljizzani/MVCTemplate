using ClinicApi.Data;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Services;
using ClinicApi.Services.PersonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IPersonService _personSerice;
        private readonly TokenRoles _tokenRoles;
        public PersonController(IAuditService auditService, IPersonService personSerice, TokenRoles tokenRoles)
        {
            _auditService = auditService;
            _personSerice = personSerice;
            _tokenRoles = tokenRoles;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PersonDto>>> Get()
        {
            // await _auditService.PostAudit("View All Person For User");
            return Ok(await _personSerice.GetAllPerson());
        }
        [HttpGet("GetCount")]
        public async Task<ActionResult<PersonDto>> GetCount()
        {
            // await _auditService.PostAudit("View All Person Count For User");
            var userEntity = _tokenRoles.GetRoleToken("EntityID");
            return Ok(await _personSerice.GetPersonCountByEntityID(int.Parse(userEntity)));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetSingle(int id)
        {
            await _auditService.PostAudit($"View Single Person By Id With Id Number '{id}' For User");
            return Ok(await _personSerice.GetPersonByID(id));
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetPersonsByNationalId")]
        public async Task<ActionResult<string>> GetPersonsByNationalId(string id)
        {
            await _auditService.PostAuditWuthNoToken($"View Single Person By National Id With National Id Number '{id}'", id);
            return Ok(await _personSerice.GetPersonByNationalId(id));
        }
        [HttpGet]
        [Route("CheckPersonByNationalId")]
        public async Task<ActionResult<string>> CheckPersonByNationalId(string id)
        {
            await _auditService.PostAuditWuthNoToken($"View Single Person By National Id Exist Or Not With National Id Number '{id}'", id);
            return Ok(await _personSerice.CheckPersonByNationalId(id));
        }
        [HttpGet]
        [Route("GetPersonsByEntity")]
        public async Task<ActionResult<List<PersonDto>>> GetPersonsByEntity(int id)
        {
            await _auditService.PostAudit($"View Single Person By Entity Id With Entity Id Number '{id}' For User");
            return Ok(await _personSerice.GetPersonsByEntityID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<PersonDto>>> AddnewPerson(InsertPersonDto newPerson)
        {
            await _auditService.PostAudit($"Insert Person '{newPerson.NationalId + " With Name " + newPerson.FullArabicName}' By User ");
            // var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            // if (int.Parse(userEntity.Value.ToString()) != newPerson.EntityId)
            //     return BadRequest("Person Entity Must Match With Your Entity");
            return Ok(await _personSerice.AddNewPerson(newPerson));
        }
        [HttpPost]
        [Route("EditPerson")]
        public async Task<ActionResult<UpdatePersonDto>> UpdatePerson(UpdatePersonDto updatePerson)
        {
            var person = JsonConvert.SerializeObject(updatePerson);
            var response = await _personSerice.UpdatePerson(updatePerson);
            await _auditService.PutAudit($"Update Person '  {person}  ' By User ", response.OldData);
            // var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            // var role = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "Role");
            // if (role.Value.ToString() != "SuperAdmin" && role.Value.ToString() != "PortalAdmin")
            // {
            // if (int.Parse(userEntity.Value.ToString()) != updatePerson.EntityId)
            //     return BadRequest("Person Entity Must Match With Your Entity");
            // }
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("EditPersonIsImportant")]
        public async Task<ActionResult<UpdatePersonDto>> UpdatePersonIsImportant(UpdatePersonIsImportantDto updatePerson)
        {
            var person = JsonConvert.SerializeObject(updatePerson);
            var response = await _personSerice.UpdatePersonIsImportant(updatePerson);
            await _auditService.PutAudit($"Update Person IsImportant'  {person}  ' By User ", response.OldData);
            // var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            // var role = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "Role");
            // if (role.Value.ToString() != "SuperAdmin" && role.Value.ToString() != "PortalAdmin")
            // {
            // if (int.Parse(userEntity.Value.ToString()) != updatePerson.EntityId)
            //     return BadRequest("Person Entity Must Match With Your Entity");
            // }
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<PersonDto>> DeletePerson(int id)
        // {
        //     return Ok(await _personSerice.DeletePerson(id));
        // }
    }
}
