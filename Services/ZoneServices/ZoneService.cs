using System;
using System.Text;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Dtos.ZoneModelDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.Models.ZoneModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClinicApi.Services.ZoneServices;

public class ZoneService : IZoneSerice
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly MagicString _magicString;

    public ZoneService(MagicString magicString, IMapper mapper, DataContext context)
    {
        _magicString = magicString;
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<ZoneDto>>> AddNewZone(ZoneDto newZone)
    {
        var serviceResponse = new ServiceResponse<List<ZoneDto>>();
        var zone = _mapper.Map<Zone>(newZone);
        _context.Zone.Add(zone);
        _context.SaveChanges();
        serviceResponse.Message = _magicString.InsertSuccess;
        serviceResponse.Data = await _context.Zone.Select(z => _mapper.Map<ZoneDto>(z)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<ZoneDto>> DeleteZone(int id)
    {
        var serviceResponse = new ServiceResponse<ZoneDto>();
        try
        {
            var zone = await _context.Zone.FirstOrDefaultAsync(z => z.Id == id);
            if (zone is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<ZoneDto>(zone);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ZoneDto>>> GetAllZone()
    {
        var serviceResponse = new ServiceResponse<List<ZoneDto>>();
        var dbContext = await _context.Zone.ToListAsync();
        serviceResponse.Data = dbContext.Select(z => _mapper.Map<ZoneDto>(z)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<ZoneDto>> GetZoneByID(int id)
    {
        var serviceResponse = new ServiceResponse<ZoneDto>();
        var dbContext = await _context.Zone.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<ZoneDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<ZoneDto>> UpdateZone(UpdateZoneDto updateZone)
    {
        var serviceResponse = new ServiceResponse<ZoneDto>();
        try
        {
            var zone = await _context.Zone.FirstOrDefaultAsync(z => z.Id == updateZone.Id);
            var OldData = await _context.Zone.FirstOrDefaultAsync(e => e.Id == updateZone.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (zone is null)
            {
                throw new Exception($"The Id '{updateZone.Id}'Is Not Founde...");
            }
            _mapper.Map(updateZone, zone);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<ZoneDto>(zone);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
