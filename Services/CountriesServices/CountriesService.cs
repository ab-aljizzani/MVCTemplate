using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.CountriesDto.Get;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.CountriesServices;

public class CountriesService : ICountriesService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CountriesService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<GetCountrieDto>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<GetCountrieDto>>();
        var dbContext = await _context.Countries.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<GetCountrieDto>(e)).ToList();
        return serviceResponse;
    }
}
