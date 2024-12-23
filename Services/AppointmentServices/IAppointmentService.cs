using System;
using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.AppointmentDto.Insert;
using ClinicApi.Dtos.AppointmentDto.Update;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.AppointmentServices;

public interface IAppointmentService
{
    Task<ServiceResponse<List<AppointmentDto>>> GetAllAppointment();
    Task<ServiceResponse<AppointmentDto>> GetAppointmentByID(int id);
    Task<ServiceResponse<AppointmentDto>> GetAppointmentByReqID(int id);
    Task<ServiceResponse<List<AppointmentDto>>> AddNewAppointment(InsertAppointmentDto newAppointment);
    Task<ServiceResponse<AppointmentDto>> UpdateAppointment(UpdateAppointmentDto updateAppointment);
    Task<ServiceResponse<AppointmentDto>> UpdateIsPersonShowUp(UpdateIsPersonShowup updateAppointment);
    Task<ServiceResponse<AppointmentDto>> UpdateSurvTypeIdByReqId(UpdateAppointmentSurveyTypeIdDto updateAppointment);
    Task<ServiceResponse<AppointmentDto>> DeleteAppointment(int id);

    Task<ServiceResponse<List<AppointmentStatusDto>>> GetAllAppointmentStatus();
    Task<ServiceResponse<AppointmentStatusDto>> GetAppointmentStatusByID(int id);
    Task<ServiceResponse<List<AppointmentStatusDto>>> AddNewAppointmentStatus(InsertAppointmentStatusDto newAppointmentStatus);
    Task<ServiceResponse<AppointmentStatusDto>> UpdateAppointmentStatus(UpdateAppointmentStatusDto updateAppointmentStatus);
    Task<ServiceResponse<AppointmentStatusDto>> DeleteAppointmentStatus(int id);

    Task<ServiceResponse<List<PerscritionDto>>> GetAllPerscrition();
    Task<ServiceResponse<PerscritionDto>> GetPerscritionByID(int id);
    Task<ServiceResponse<List<PerscritionDto>>> AddNewPerscrition(InsertPerscriptionDto newPerscrition);
    Task<ServiceResponse<PerscritionDto>> UpdatePerscrition(UpdatePerscriptionDto updatePerscrition);
    Task<ServiceResponse<PerscritionDto>> DeletePerscrition(int id);
}
