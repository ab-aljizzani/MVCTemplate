using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.DoctorAvailbleTimeDto;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Insert;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Update;
using ClinicApi.Models.DoctorAvailbleTimeModel;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.DoctorAvailbleTimeServices;

public class DoctorAvailbleTimeService : IDoctorAvailbleTimeService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public DoctorAvailbleTimeService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<GetDoctorAvailbleTimeDto>>> AddNewTime(InsertDoctorAvailbleTimeDto newTime)
    {
        var serviceResponse = new ServiceResponse<List<GetDoctorAvailbleTimeDto>>();
        var time = _mapper.Map<DoctorAvailbleTime>(newTime);
        _context.DoctorAvailbleTime.Add(time);
        _context.SaveChanges();
        serviceResponse.Data = await _context.DoctorAvailbleTime.Select(e => _mapper.Map<GetDoctorAvailbleTimeDto>(e)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetDoctorAvailbleTimeDto>> DeleteTime(int id)
    {
        var serviceResponse = new ServiceResponse<GetDoctorAvailbleTimeDto>();
        try
        {
            var time = await _context.DoctorAvailbleTime.FirstOrDefaultAsync(e => e.Id == id);
            if (time is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.DoctorAvailbleTime.Remove(time);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDoctorAvailbleTimeDto>(time);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetDoctorAvailbleTimeDto>>> GetAllTime()
    {
        var serviceResponse = new ServiceResponse<List<GetDoctorAvailbleTimeDto>>();
        var dbContext = await _context.DoctorAvailbleTime.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<GetDoctorAvailbleTimeDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetDoctorAvailbleTimeDto>> GetTimeByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetDoctorAvailbleTimeDto>();
        var dbContext = await _context.DoctorAvailbleTime.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetDoctorAvailbleTimeDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetDoctorAvailbleTimeDto>> UpdateTime(UpdateDoctorAvailbleTimeDto updateTime)
    {
        var serviceResponse = new ServiceResponse<GetDoctorAvailbleTimeDto>();
        try
        {
            var time = await _context.DoctorAvailbleTime.FirstOrDefaultAsync(e => e.Id == updateTime.Id);
            if (time is null)
            {
                throw new Exception($"The Id '{updateTime.Id}'Is Not Founde...");
            }
            _mapper.Map(updateTime, time);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDoctorAvailbleTimeDto>(time);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
