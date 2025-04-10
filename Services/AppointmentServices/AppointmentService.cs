using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.AppointmentDto.Get;
using ClinicApi.Dtos.AppointmentDto.Insert;
using ClinicApi.Dtos.AppointmentDto.Update;
using ClinicApi.Models.AppointmentModel;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Services.AppointmentServices;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public AppointmentService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<int>> AddNewAppointment(InsertAppointmentDto newAppointment)
    {
        var serviceResponse = new ServiceResponse<int>();
        var appointment = _mapper.Map<Appointment>(newAppointment);
        _context.Appointment.Add(appointment);
        _context.SaveChanges();
        serviceResponse.Data = appointment.Id;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<AppointmentStatusDto>>> AddNewAppointmentStatus(InsertAppointmentStatusDto newAppointmentStatus)
    {
        var serviceResponse = new ServiceResponse<List<AppointmentStatusDto>>();
        var appointmentStatus = _mapper.Map<AppointmentStatus>(newAppointmentStatus);
        _context.AppointmentStatus.Add(appointmentStatus);
        _context.SaveChanges();
        serviceResponse.Data = await _context.AppointmentStatus.Select(e => _mapper.Map<AppointmentStatusDto>(e)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PerscritionDto>>> AddNewPerscrition(InsertPerscriptionDto newPerscrition)
    {
        var serviceResponse = new ServiceResponse<List<PerscritionDto>>();
        var perscrition = _mapper.Map<Perscription>(newPerscrition);
        _context.Perscription.Add(perscrition);
        _context.SaveChanges();
        serviceResponse.Data = await _context.Perscription.Select(e => _mapper.Map<PerscritionDto>(e)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> DeleteAppointment(int id)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        try
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(e => e.Id == id);
            if (appointment is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentDto>(appointment);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentStatusDto>> DeleteAppointmentStatus(int id)
    {
        var serviceResponse = new ServiceResponse<AppointmentStatusDto>();
        try
        {
            var appointmentStatus = await _context.AppointmentStatus.FirstOrDefaultAsync(e => e.Id == id);
            if (appointmentStatus is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.AppointmentStatus.Remove(appointmentStatus);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentStatusDto>(appointmentStatus);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<PerscritionDto>> DeletePerscrition(int id)
    {
        var serviceResponse = new ServiceResponse<PerscritionDto>();
        try
        {
            var perscritionDto = await _context.Perscription.FirstOrDefaultAsync(e => e.Id == id);
            if (perscritionDto is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Perscription.Remove(perscritionDto);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PerscritionDto>(perscritionDto);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<AppointmentDto>>> GetAllAppointment()
    {
        var serviceResponse = new ServiceResponse<List<AppointmentDto>>();
        var dbContext = await _context.Appointment.Include(e => e.RiskLevel).Include(e => e.SurveyType).Include(e => e.portalUser).ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<AppointmentDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<AppointmentStatusDto>>> GetAllAppointmentStatus()
    {
        var serviceResponse = new ServiceResponse<List<AppointmentStatusDto>>();
        var dbContext = await _context.AppointmentStatus.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<AppointmentStatusDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PerscritionDto>>> GetAllPerscrition()
    {
        var serviceResponse = new ServiceResponse<List<PerscritionDto>>();
        var dbContext = await _context.Perscription.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<PerscritionDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> GetAppointmentByID(int id)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        var dbContext = await _context.Appointment.Include(e => e.RiskLevel).Include(e => e.SurveyType).Include(e => e.portalUser).FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<AppointmentDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> GetAppointmentByReqID(int id)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        var dbContext = await _context.Appointment.Where(e => e.Id == id).Include(e => e.RiskLevel).Include(e => e.SurveyType).Include(e => e.portalUser).FirstOrDefaultAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<AppointmentDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentStatusDto>> GetAppointmentStatusByID(int id)
    {
        var serviceResponse = new ServiceResponse<AppointmentStatusDto>();
        var dbContext = await _context.AppointmentStatus.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<AppointmentStatusDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<object>>> GetPerscritionByAppID(int id)
    {
        var serviceResponse = new ServiceResponse<List<object>>();
        var dbContext = await _context.Perscription.Where(e => e.AppointmentId == id && e.PortalUserId == e.PortalUser.Id && e.PortalUser.RoleId == e.PortalUser.Role.Id).Select(e => new { e.AppointmentId, e.PerscriptionName, e.CreateDate, e.Discription, e.PortalUser.UserFullName, e.PortalUser.Role.RoleArabName }).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<object>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<PerscritionDto>> GetPerscritionByID(int id)
    {
        var serviceResponse = new ServiceResponse<PerscritionDto>();
        var dbContext = await _context.Perscription.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<PerscritionDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> UpdateAppointment(UpdateAppointmentDto updateAppointment)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        try
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(e => e.Id == updateAppointment.Id);
            if (appointment is null)
            {
                throw new Exception($"The Id '{updateAppointment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointment, appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentDto>(appointment);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> UpdateAppointmentDoctorReview(UpdateAppointmentDoctorReviewDto updateAppointment)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        try
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(e => e.Id == updateAppointment.Id);
            if (appointment is null)
            {
                throw new Exception($"The Id '{updateAppointment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointment, appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentDto>(appointment);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> UpdateAppointmentIsSurvInserted(UpdateAppointmentIsSurveyInsertedDto updateAppointment)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        try
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(e => e.Id == updateAppointment.Id);
            if (appointment is null)
            {
                throw new Exception($"The Id '{updateAppointment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointment, appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentDto>(appointment);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> UpdateAppointmentReview(UpdateAppointmentReviewDto updateAppointment)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        try
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(e => e.Id == updateAppointment.Id);
            if (appointment is null)
            {
                throw new Exception($"The Id '{updateAppointment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointment, appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentDto>(appointment);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentStatusDto>> UpdateAppointmentStatus(UpdateAppointmentStatusDto updateAppointmentStatus)
    {
        var serviceResponse = new ServiceResponse<AppointmentStatusDto>();
        try
        {
            var appointmentStatus = await _context.AppointmentStatus.FirstOrDefaultAsync(e => e.Id == updateAppointmentStatus.Id);
            if (appointmentStatus is null)
            {
                throw new Exception($"The Id '{updateAppointmentStatus.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointmentStatus, appointmentStatus);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentStatusDto>(appointmentStatus);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> UpdateIsPersonShowUp(UpdateIsPersonShowup updateAppointment)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        try
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(e => e.Id == updateAppointment.Id);
            if (appointment is null)
            {
                throw new Exception($"The Id '{updateAppointment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointment, appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentDto>(appointment);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<PerscritionDto>> UpdatePerscrition(UpdatePerscriptionDto updatePerscrition)
    {
        var serviceResponse = new ServiceResponse<PerscritionDto>();
        try
        {
            var perscrition = await _context.Perscription.FirstOrDefaultAsync(e => e.Id == updatePerscrition.Id);
            if (perscrition is null)
            {
                throw new Exception($"The Id '{updatePerscrition.Id}'Is Not Founde...");
            }
            _mapper.Map(updatePerscrition, perscrition);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<PerscritionDto>(perscrition);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<AppointmentDto>> UpdateSurvTypeIdByReqId(UpdateAppointmentSurveyTypeIdDto updateAppointment)
    {
        var serviceResponse = new ServiceResponse<AppointmentDto>();
        try
        {
            var appointment = await _context.Appointment.FirstOrDefaultAsync(e => e.Id == updateAppointment.Id);
            if (appointment is null)
            {
                throw new Exception($"The Id '{updateAppointment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointment, appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<AppointmentDto>(appointment);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
