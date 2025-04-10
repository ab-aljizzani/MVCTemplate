using System;
using ClinicApi.Dtos.CountriesDto.Get;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.CountriesServices;

public interface ICountriesService
{
    Task<ServiceResponse<List<GetCountrieDto>>> GetAll();
}
