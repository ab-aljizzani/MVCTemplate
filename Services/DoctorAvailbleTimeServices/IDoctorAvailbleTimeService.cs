using System;
using ClinicApi.Dtos.DoctorAvailbleTimeDto;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Insert;
using ClinicApi.Dtos.DoctorAvailbleTimeDto.Update;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.DoctorAvailbleTimeServices;

public interface IDoctorAvailbleTimeService
{
    Task<ServiceResponse<List<GetDoctorAvailbleTimeDto>>> GetAllTime();
    Task<ServiceResponse<GetDoctorAvailbleTimeDto>> GetTimeByID(int id);
    Task<ServiceResponse<GetDoctorAvailbleTimeDto>> GetTimeByDoctorID(int id);
    Task<ServiceResponse<List<GetDoctorAvailbleTimeDto>>> AddNewTime(InsertDoctorAvailbleTimeDto newTime);
    Task<ServiceResponse<GetDoctorAvailbleTimeDto>> UpdateTime(UpdateDoctorAvailbleTimeDto updateTime);
    Task<ServiceResponse<GetDoctorAvailbleTimeDto>> UpdateIsActive(UpdateDoctorIsActive updateTime);
    Task<ServiceResponse<GetDoctorAvailbleTimeDto>> DeleteTime(int id);
}
