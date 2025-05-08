using System;
using System.Text;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.ApoointmentReviewDto.Get;
using ClinicApi.Dtos.ApoointmentReviewDto.Insert;
using ClinicApi.Dtos.ApoointmentReviewDto.Update;
using ClinicApi.Models.AppintmentReviewModel;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClinicApi.Services.AppointmentReviewServices;

public class AppointmentReviewService : IAppointmentReviewService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public AppointmentReviewService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<GetAppointmentReviewDto>>> AddNewAppointmentReview(InsertAppointmentReviewDto newAppointmentReview)
    {
        var serviceResponse = new ServiceResponse<List<GetAppointmentReviewDto>>();
        var appointmentReview = _mapper.Map<AppointmentReview>(newAppointmentReview);
        _context.AppointmentReview.Add(appointmentReview);
        _context.SaveChanges();
        serviceResponse.Data = await _context.AppointmentReview.Select(e => _mapper.Map<GetAppointmentReviewDto>(e)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetAppointmentReviewDto>> DeleteAppointmentReview(int id)
    {
        var serviceResponse = new ServiceResponse<GetAppointmentReviewDto>();
        try
        {
            var appointmentReview = await _context.AppointmentReview.FirstOrDefaultAsync(e => e.Id == id);
            if (appointmentReview is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.AppointmentReview.Remove(appointmentReview);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetAppointmentReviewDto>(appointmentReview);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetAppointmentReviewDto>>> GetAllAppointmentReview()
    {
        var serviceResponse = new ServiceResponse<List<GetAppointmentReviewDto>>();
        var dbContext = await _context.AppointmentReview.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<GetAppointmentReviewDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<object>>> GetAppointmentReviewByAppointmentId(int id)
    {
        var serviceResponse = new ServiceResponse<List<object>>();
        // var dbContext = await _context.AppointmentReview.Where(e => e.AppointmentId == id).Include(e => e.PortalUser).ToListAsync();
        var dbContext = await _context.AppointmentReview.Where(e => e.AppointmentId == id && e.PortalUserId == e.PortalUser.Id && e.PortalUser.RoleId == e.PortalUser.Role.Id).Select(s => new { s.Review, s.ReviewDate, s.PortalUser.UserFullName, s.PortalUser.Role.RoleName, s.PortalUser.Role.RoleArabName }).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<object>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetAppointmentReviewDto>> GetAppointmentReviewByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetAppointmentReviewDto>();
        var dbContext = await _context.AppointmentReview.Where(e => e.AppointmentId == id).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetAppointmentReviewDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetAppointmentReviewDto>> UpdateAppointmentReview(UpdateAppointmentReview_Dto updateAppointmentReview)
    {
        var serviceResponse = new ServiceResponse<GetAppointmentReviewDto>();
        try
        {
            var appointmentReview = await _context.AppointmentReview.FirstOrDefaultAsync(e => e.Id == updateAppointmentReview.Id);
            var OldData = await _context.AppointmentReview.FirstOrDefaultAsync(e => e.Id == updateAppointmentReview.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (appointmentReview is null)
            {
                throw new Exception($"The Id '{updateAppointmentReview.Id}'Is Not Founde...");
            }
            _mapper.Map(updateAppointmentReview, appointmentReview);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetAppointmentReviewDto>(appointmentReview);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
