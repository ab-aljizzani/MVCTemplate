using System;
using MVCTemplate.Dtos.CountriesDto.Get;
using MVCTemplate.Models.Reponse;

namespace MVCTemplate.Services.CountriesServices;

public interface ICountriesService
{
    Task<ServiceResponse<List<GetCountrieDto>>> GetAll();
}
