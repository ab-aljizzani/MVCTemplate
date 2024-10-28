using System;
using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.PersonalImagesServices;

public interface IPersonalImages
{
    Task<ServiceResponse<List<PersonalImgDto>>> GetAllPersonalImages();
    Task<ServiceResponse<PersonalImgDto>> GetPersonalImagesByID(int id);
    Task<ServiceResponse<List<PersonalImgDto>>> AddNewPersonalImages(PersonalImgDto newPersonalImages);
    Task<ServiceResponse<PersonalImgDto>> UpdatePersonalImages(UpdatePersonalImgDto updatePersonalImages);
    Task<ServiceResponse<PersonalImgDto>> DeletePersonalImages(int id);
}
