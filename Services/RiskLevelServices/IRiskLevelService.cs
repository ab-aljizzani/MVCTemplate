using System;
using ClinicApi.Dtos.RiskLevelDto.Get;
using ClinicApi.Dtos.RiskLevelDto.Insert;
using ClinicApi.Dtos.RiskLevelDto.Update;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.RiskLevelServices;

public interface IRiskLevelService
{
    Task<ServiceResponse<List<GetRiskLevelDto>>> GetAllRisk();
    Task<ServiceResponse<GetRiskLevelDto>> GetRiskByID(int id);
    Task<ServiceResponse<List<GetRiskLevelDto>>> AddNewRisk(InsertRiskLevelDto newRisk);
    Task<ServiceResponse<GetRiskLevelDto>> UpdateRisk(UpdateRiskLevelDto updateRisk);
    Task<ServiceResponse<GetRiskLevelDto>> DeleteRisk(int id);
}
