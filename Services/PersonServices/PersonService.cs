using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.PersonServices;

public class PersonService : IPersonService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public PersonService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<PersonDto>>> AddNewPerson(PersonDto newPerson)
    {
        var serviceResponse = new ServiceResponse<List<PersonDto>>();
        var person = _mapper.Map<Person>(newPerson);
        _context.Person.Add(person);
        _context.SaveChanges();
        serviceResponse.Data = await _context.Person.Select(p => _mapper.Map<PersonDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<PersonDto>> DeletePerson(int id)
    {
        var serviceResponse = new ServiceResponse<PersonDto>();
        try
        {
            var person = await _context.Person.FirstOrDefaultAsync(p => p.Id == id);
            if (person is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PersonDto>(person);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PersonDto>>> GetAllPerson()
    {
        var serviceResponse = new ServiceResponse<List<PersonDto>>();
        var dbContext = await _context.Person.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PersonDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<PersonDto>> GetPersonByID(int id)
    {
        var serviceResponse = new ServiceResponse<PersonDto>();
        var dbContext = await _context.Person.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<PersonDto>(dbContext);
        return serviceResponse;
    }
    public async Task<string> GetPersonCountByEntityID(int id)
    {
        var dbContext = await _context.Person.ToListAsync();
        var count = dbContext.Count();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }

        return count.ToString();
    }

    public async Task<ServiceResponse<List<PersonDto>>> GetPersonsByEntityID(int id)
    {
        var serviceResponse = new ServiceResponse<List<PersonDto>>();
        var dbContext = await _context.Person.Include(p => p.Zone).Include(p => p.Department).Include(p => p.PersonalImg).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PersonDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<PersonDto>> UpdatePerson(UpdatePersonDto updatePerson)
    {
        var serviceResponse = new ServiceResponse<PersonDto>();
        try
        {
            var person = await _context.Person.FirstOrDefaultAsync(z => z.Id == updatePerson.Id);
            if (person is null)
            {
                throw new Exception($"The Id '{updatePerson.Id}'Is Not Founde...");
            }
            _mapper.Map(updatePerson, person);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PersonDto>(person);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
