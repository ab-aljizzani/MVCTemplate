using ClinicApi.Data;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Services.PersonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personSerice;
        private readonly TokenRoles _tokenRoles;
        public PersonController(IPersonService personSerice, TokenRoles tokenRoles)
        {
            _personSerice = personSerice;
            _tokenRoles = tokenRoles;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PersonDto>>> Get()
        {
            return Ok(await _personSerice.GetAllPerson());
        }
        [HttpGet("GetCount")]
        public async Task<ActionResult<PersonDto>> GetCount()
        {
            var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            return Ok(await _personSerice.GetPersonCountByEntityID(int.Parse(userEntity.Value.ToString())));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetSingle(int id)
        {
            return Ok(await _personSerice.GetPersonByID(id));
        }
        [HttpGet]
        [Route("GetPersonsByEntity")]
        public async Task<ActionResult<List<PersonDto>>> GetPersonsByEntity(int id)
        {
            return Ok(await _personSerice.GetPersonsByEntityID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<PersonDto>>> AddnewPerson(InsertPersonDto newPerson)
        {
            var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            if (int.Parse(userEntity.Value.ToString()) != newPerson.EntityId)
                return BadRequest("Person Entity Must Match With Your Entity");
            return Ok(await _personSerice.AddNewPerson(newPerson));
        }
        [HttpPut]
        public async Task<ActionResult<UpdatePersonDto>> UpdatePerson(UpdatePersonDto updatePerson)
        {
            var userEntity = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "EntityID");
            var role = _tokenRoles.GetRoleToken().FirstOrDefault(g => g.Key == "Role");
            if (role.Value.ToString() != "SuperAdmin" && role.Value.ToString() != "PortalAdmin")
            {
                if (int.Parse(userEntity.Value.ToString()) != updatePerson.EntityId)
                    return BadRequest("Person Entity Must Match With Your Entity");
            }
            var response = await _personSerice.UpdatePerson(updatePerson);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonDto>> DeletePerson(int id)
        {
            return Ok(await _personSerice.DeletePerson(id));
        }
    }
}
