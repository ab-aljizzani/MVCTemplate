using System;
using ClinicApi.Dtos.SickLeaveDto.Get;
using ClinicApi.Dtos.SickLeaveDto.Insert;
using ClinicApi.Dtos.SickLeaveDto.Update;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.SickLeaveServices;

public interface ISickLeaveService
{
    Task<ServiceResponse<List<GetSickLeaveDto>>> GetAllSickLeave();
    Task<ServiceResponse<GetSickLeaveDto>> GetSickLeaveByID(int id);
    Task<ServiceResponse<List<GetSickLeaveDto>>> AddNewSickLeave(InsertSickLeaveDto newSickLeave);
    Task<ServiceResponse<GetSickLeaveDto>> UpdateSickLeave(UpdateSickLeaveDto updateSickLeave);
    Task<ServiceResponse<GetSickLeaveDto>> DeleteSickLeave(int id);
}
