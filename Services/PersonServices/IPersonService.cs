using System;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.PersonServices;

public interface IPersonService
{
    Task<ServiceResponse<List<PersonDto>>> GetAllPerson();
    Task<ServiceResponse<PersonDto>> GetPersonByID(int id);
    Task<ServiceResponse<string>> GetPersonByNationalId(string id);
    Task<ServiceResponse<bool>> CheckPersonByNationalId(string id);
    Task<ServiceResponse<List<PersonDto>>> GetPersonsByEntityID(int id);
    Task<string> GetPersonCountByEntityID(int id);
    Task<ServiceResponse<List<PersonDto>>> AddNewPerson(InsertPersonDto newPerson);
    Task<ServiceResponse<UpdatePersonDto>> UpdatePerson(UpdatePersonDto updatePerson);
    Task<ServiceResponse<PersonDto>> DeletePerson(int id);
}
