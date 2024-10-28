using System;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.PersonServices;

public interface IPersonService
{
    Task<ServiceResponse<List<PersonDto>>> GetAllPerson();
    Task<ServiceResponse<PersonDto>> GetPersonByID(int id);
    Task<ServiceResponse<List<PersonDto>>> AddNewPerson(PersonDto newPerson);
    Task<ServiceResponse<PersonDto>> UpdatePerson(UpdatePersonDto updatePerson);
    Task<ServiceResponse<PersonDto>> DeletePerson(int id);
}
