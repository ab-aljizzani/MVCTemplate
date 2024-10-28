using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Services.PersonalImagesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalImgController : ControllerBase
    {
        private readonly IPersonalImages _personalImages;

        public PersonalImgController(IPersonalImages personalImages)
        {
            _personalImages = personalImages;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PersonalImgDto>>> Get()
        {
            return Ok(await _personalImages.GetAllPersonalImages());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalImgDto>> GetSingle(int id)
        {
            return Ok(await _personalImages.GetPersonalImagesByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<List<PersonalImgDto>>> AddnewZone([FromForm] PersonalImgDto newZone)
        {
            return Ok(await _personalImages.AddNewPersonalImages(newZone));
        }
        [HttpPut]
        public async Task<ActionResult<PersonalImgDto>> UpdateZone([FromForm] UpdatePersonalImgDto updateZone)
        {
            var response = await _personalImages.UpdatePersonalImages(updateZone);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalImgDto>> DeleteZone(int id)
        {
            return Ok(await _personalImages.DeletePersonalImages(id));
        }
    }
}
