using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.SickLeaveDto.Get;
using ClinicApi.Dtos.SickLeaveDto.Insert;
using ClinicApi.Dtos.SickLeaveDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.Models.SickLeaveModel;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.SickLeaveServices;

public class SickLeaveService : ISickLeaveService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public SickLeaveService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<GetSickLeaveDto>>> AddNewSickLeave(InsertSickLeaveDto newSickLeave)
    {
        var serviceResponse = new ServiceResponse<List<GetSickLeaveDto>>();
        var sickLeave = _mapper.Map<SickLeave>(newSickLeave);
        _context.SickLeave.Add(sickLeave);
        _context.SaveChanges();
        serviceResponse.Data = await _context.SickLeave.Select(e => _mapper.Map<GetSickLeaveDto>(e)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSickLeaveDto>> DeleteSickLeave(int id)
    {
        var serviceResponse = new ServiceResponse<GetSickLeaveDto>();
        try
        {
            var sickLeave = await _context.SickLeave.FirstOrDefaultAsync(e => e.Id == id);
            if (sickLeave is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.SickLeave.Remove(sickLeave);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSickLeaveDto>(sickLeave);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSickLeaveDto>>> GetAllSickLeave()
    {
        var serviceResponse = new ServiceResponse<List<GetSickLeaveDto>>();
        var dbContext = await _context.SickLeave.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<GetSickLeaveDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<object>>> GetSickLeaveByAppointmentID(int id)
    {
        var serviceResponse = new ServiceResponse<List<object>>();
        var dbContext = await _context.SickLeave.Where(e => e.AppointmentId == id && e.PortalUserId == e.PortalUser.Id && e.PortalUser.RoleId == e.PortalUser.Role.Id).Select(e => new { e.AppointmentId, e.StartDate, e.CreateDate, e.NumberOfDays, e.PortalUser.UserFullName, e.PortalUser.Role.RoleArabName }).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<object>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSickLeaveDto>> GetSickLeaveByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetSickLeaveDto>();
        var dbContext = await _context.SickLeave.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetSickLeaveDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSickLeaveDto>> UpdateSickLeave(UpdateSickLeaveDto updateSickLeave)
    {
        var serviceResponse = new ServiceResponse<GetSickLeaveDto>();
        try
        {
            var sickLeave = await _context.SickLeave.FirstOrDefaultAsync(e => e.Id == updateSickLeave.Id);
            if (sickLeave is null)
            {
                throw new Exception($"The Id '{updateSickLeave.Id}'Is Not Founde...");
            }
            _mapper.Map(updateSickLeave, sickLeave);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSickLeaveDto>(sickLeave);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
