using System;
using System.Text;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
    public async Task<ServiceResponse<List<PersonDto>>> AddNewPerson(InsertPersonDto newPerson)
    {
        var serviceResponse = new ServiceResponse<List<PersonDto>>();
        if (newPerson.PersonalImgId == 0 || newPerson?.PersonalImgId == null)
        {
            var personDto = _mapper.Map<InsertPersonNoPersonImgDto>(newPerson);
            var person = _mapper.Map<Person>(personDto);
            _context.Person.Add(person);
            _context.SaveChanges();
            serviceResponse.Data = await _context.Person.Select(p => _mapper.Map<PersonDto>(p)).ToListAsync();
        }
        else
        {
            var person = _mapper.Map<Person>(newPerson);
            _context.Person.Add(person);
            _context.SaveChanges();
            serviceResponse.Data = await _context.Person.Select(p => _mapper.Map<PersonDto>(p)).ToListAsync();
        }
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
        var dbContext = await _context.Person.Include(p => p.Zone).Include(p => p.Department).Include(p => p.Entity).Include(p => p.PersonalImg).ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PersonDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<PersonDto>> GetPersonByID(int id)
    {
        var serviceResponse = new ServiceResponse<PersonDto>();
        var dbContext = await _context.Person.Include(p => p.Entity).Include(p => p.Zone).Include(p => p.Department).Include(p => p.PersonalImg).FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<PersonDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<string>> GetPersonByNationalId(string id)
    {
        var serviceResponse = new ServiceResponse<string>();
        var dbContext = await _context.Person.Where(p => p.NationalId == id).Select(p => p.Id).FirstOrDefaultAsync();
        if (dbContext <= 0)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.ToString();
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
        var dbContext = await _context.Person.Where(p => p.EntityId == id).Include(p => p.Zone).Include(p => p.Department).Include(p => p.PersonalImg).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }

        serviceResponse.Data = dbContext.Select(p => _mapper.Map<PersonDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdatePersonDto>> UpdatePerson(UpdatePersonDto updatePerson)
    {
        var serviceResponse = new ServiceResponse<UpdatePersonDto>();
        try
        {
            var person = await _context.Person.FirstOrDefaultAsync(z => z.Id == updatePerson.Id);
            var OldData = await _context.Person.FirstOrDefaultAsync(e => e.Id == updatePerson.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (person is null)
            {
                throw new Exception($"The Id '{updatePerson.Id}'Is Not Founde...");
            }
            if (updatePerson.PersonalImgId == 0 || updatePerson?.PersonalImgId == null)
            {
                var personDto = _mapper.Map<UpdatePersonNoPersonalImgDto>(updatePerson);
                _mapper.Map(personDto, person);
                // var person = _mapper.Map<Person>(personDto);
                // _context.Person.Add(person);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UpdatePersonDto>(person);
            }
            else
            {
                _mapper.Map(updatePerson, person);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UpdatePersonDto>(person);
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

}
