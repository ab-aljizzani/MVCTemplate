using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.RiskLevelDto.Get;
using ClinicApi.Dtos.RiskLevelDto.Insert;
using ClinicApi.Dtos.RiskLevelDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.Models.RiskLevelModel;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.RiskLevelServices;

public class RiskLevelService : IRiskLevelService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public RiskLevelService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<GetRiskLevelDto>>> AddNewRisk(InsertRiskLevelDto newRisk)
    {
        var serviceResponse = new ServiceResponse<List<GetRiskLevelDto>>();
        var risk = _mapper.Map<RiskLevel>(newRisk);
        _context.RiskLevel.Add(risk);
        _context.SaveChanges();
        serviceResponse.Data = await _context.RiskLevel.Select(e => _mapper.Map<GetRiskLevelDto>(e)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRiskLevelDto>> DeleteRisk(int id)
    {
        var serviceResponse = new ServiceResponse<GetRiskLevelDto>();
        try
        {
            var risk = await _context.RiskLevel.FirstOrDefaultAsync(e => e.Id == id);
            if (risk is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.RiskLevel.Remove(risk);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetRiskLevelDto>(risk);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetRiskLevelDto>>> GetAllRisk()
    {
        var serviceResponse = new ServiceResponse<List<GetRiskLevelDto>>();
        var dbContext = await _context.RiskLevel.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<GetRiskLevelDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRiskLevelDto>> GetRiskByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetRiskLevelDto>();
        var dbContext = await _context.RiskLevel.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetRiskLevelDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRiskLevelDto>> UpdateRisk(UpdateRiskLevelDto updateRisk)
    {
        var serviceResponse = new ServiceResponse<GetRiskLevelDto>();
        try
        {
            var risk = await _context.RiskLevel.FirstOrDefaultAsync(e => e.Id == updateRisk.Id);
            if (risk is null)
            {
                throw new Exception($"The Id '{updateRisk.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRisk, risk);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetRiskLevelDto>(risk);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
