using System;
using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.PersonalImagesServices;

public interface IPersonalImages
{
    Task<ServiceResponse<List<PersonalImgDto>>> GetAllPersonalImages();
    Task<ServiceResponse<PersonalImgDto>> GetPersonalImagesByID(int id);
    Task<ServiceResponse<int>> AddNewPersonalImages(PersonalImgDto newPersonalImages);
    Task<ServiceResponse<int>> UpdatePersonalImages(UpdatePersonalImgDto updatePersonalImages);
    Task<ServiceResponse<PersonalImgDto>> DeletePersonalImages(int id);
}
