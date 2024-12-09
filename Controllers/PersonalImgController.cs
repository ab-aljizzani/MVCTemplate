using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Services;
using ClinicApi.Services.PersonalImagesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PersonalImgController : ControllerBase
    {
        private readonly IAuditService _auditService;
        private readonly IPersonalImages _personalImages;

        public PersonalImgController(IAuditService auditService, IPersonalImages personalImages)
        {
            _auditService = auditService;
            _personalImages = personalImages;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PersonalImgDto>>> Get()
        {
            // await _auditService.PostAudit("View All PersonalImg For User");
            return Ok(await _personalImages.GetAllPersonalImages());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalImgDto>> GetSingle(int id)
        {
            await _auditService.PostAudit($"View Single PersonalImg By Id With Id Number '{id}' For User");
            return Ok(await _personalImages.GetPersonalImagesByID(id));
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddnewPersonalImg(PersonalImgDto newPersonalImg)
        {
            await _auditService.PostAudit($"Insert PersonalImg '{newPersonalImg.Id}' By User ");
            return Ok(await _personalImages.AddNewPersonalImages(newPersonalImg));
        }
        [HttpPost]
        [Route("EditPersonalImg")]
        public async Task<ActionResult<PersonalImgDto>> UpdatePersonalImg(UpdatePersonalImgDto updatePersonalImg)
        {
            await _auditService.PostAudit($"Update PersonalImg '{updatePersonalImg.Id}' By User ");
            var response = await _personalImages.UpdatePersonalImages(updatePersonalImg);
            if (response.Success == false)
                return NotFound(response);
            return Ok(response);
        }
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<PersonalImgDto>> DeletePersonalImg(int id)
        // {
        //     return Ok(await _personalImages.DeletePersonalImages(id));
        // }
    }
}
