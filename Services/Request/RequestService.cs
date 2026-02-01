using System;
using System.Text;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.RequestDto.Get;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RequestDto.Update;
using ClinicApi.Models.Reponse;
using ClinicApi.ViewModel.Statistics;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClinicApi.Services.Request;

public class RequestService : IRequestService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public RequestService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<int>> AddNewRequest(InsertRequestDto newRequest)
    {
        var serviceResponse = new ServiceResponse<int>();
        var request = _mapper.Map<Models.RequestModel.Request>(newRequest);
        _context.Request.Add(request);
        await _context.SaveChangesAsync();
        serviceResponse.Data = request.Id;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetRequestStatusDto>>> AddNewRequestStatus(InsertRequestStatusDto newRequestStatus)
    {
        var serviceResponse = new ServiceResponse<List<GetRequestStatusDto>>();
        var request = _mapper.Map<Models.RequestModel.RequestStatus>(newRequestStatus);
        _context.RequestStatus.Add(request);
        _context.SaveChanges();
        serviceResponse.Data = await _context.RequestStatus.Select(p => _mapper.Map<GetRequestStatusDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetRequestTypeDto>>> AddNewRequestType(InsertRequestTypeDto newRequestType)
    {
        var serviceResponse = new ServiceResponse<List<GetRequestTypeDto>>();
        var request = _mapper.Map<Models.RequestTypeModel.RequestType>(newRequestType);
        _context.RequestType.Add(request);
        _context.SaveChanges();
        serviceResponse.Data = await _context.RequestType.Select(p => _mapper.Map<GetRequestTypeDto>(p)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRequestDto>> DeleteRequest(int id)
    {
        var serviceResponse = new ServiceResponse<GetRequestDto>();
        try
        {
            var request = await _context.Request.FirstOrDefaultAsync(p => p.Id == id);
            if (request is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetRequestDto>(request);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRequestStatusDto>> DeleteRequestStatus(int id)
    {
        var serviceResponse = new ServiceResponse<GetRequestStatusDto>();
        try
        {
            var requestStatus = await _context.RequestStatus.FirstOrDefaultAsync(p => p.Id == id);
            if (requestStatus is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.RequestStatus.Remove(requestStatus);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetRequestStatusDto>(requestStatus);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRequestTypeDto>> DeleteRequestType(int id)
    {
        var serviceResponse = new ServiceResponse<GetRequestTypeDto>();
        try
        {
            var requestType = await _context.RequestType.FirstOrDefaultAsync(p => p.Id == id);
            if (requestType is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.RequestType.Remove(requestType);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetRequestTypeDto>(requestType);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetRequestDto>>> GetAllRequest()
    {
        var serviceResponse = new ServiceResponse<List<GetRequestDto>>();
        // var dbContext = await _context.Request.Select(r => new { r.Person, r.RequestStatus, r.RequestType, r.Appointment, r.SurveyType ,}).Include(r => r.Person).Include(r => r.RequestStatus).Include(r => r.RequestType).Include(r => r.Appointment).Include(r => r.SurveyType).ToListAsync();
        var dbContext = await _context.Request
    .Select(r => new GetRequestDto
    {
        Id = r.Id,
        AppointmentId = r.AppointmentId,
        PersonId = r.PersonId,
        RequestStatusId = r.RequestStatusId,
        RequestTypeId = r.RequestTypeId,
        PortalUserId = r.PortalUserId,
        SurveyTypeId = r.SurveyTypeId,
        AppsentReason = r.AppsentReason,
        IsSurveyInserted = r.IsSurveyInserted,
        // Person properties
        Person = r.Person,
        // RequestStatus properties
        RequestStatus = r.RequestStatus,
        // RequestType properties
        RequestType = r.RequestType,
        // PortalUser properties (if needed)
        UserFullName = r.PortalUser.UserFullName,
        Email = r.PortalUser.Email,
        DateOfBirth = r.PortalUser.DateOfBirth,
        PhoneNumber = r.PortalUser.PhoneNumber,
        EntityId = r.PortalUser.EntityId,
        DepartmentId = r.PortalUser.DepartmentId,
        RoleId = r.PortalUser.RoleId,
        Status = r.PortalUser.Status,
        IsFromShamel = r.PortalUser.IsFromShamel,

        // PortalUserName = r.PortalUser.UserFullName,
        // Appointment properties (if needed)
        Appointment = r.Appointment,
        // SurveyType properties (if needed)
        SurveyType = r.SurveyType,
        isEmergency = r.isEmergency
    })
    .ToListAsync();

        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetRequestDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetRequestStatusDto>>> GetAllRequestStatus()
    {
        var serviceResponse = new ServiceResponse<List<GetRequestStatusDto>>();
        var dbContext = await _context.RequestStatus.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetRequestStatusDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetRequestTypeDto>>> GetAllRequestType()
    {
        var serviceResponse = new ServiceResponse<List<GetRequestTypeDto>>();
        var dbContext = await _context.RequestType.ToListAsync();
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetRequestTypeDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<object>> GetRequestByID(int id)
    {
        var serviceResponse = new ServiceResponse<object>();
        // var dbContext = await _context.Request.Where(r => r.Id == id).Include(r => r.Appointment).Include(r => r.Appointment.RiskLevel).Include(r => r.Appointment.SurveyType).Include(r => r.Person).Include(r => r.Person.Entity).Include(r => r.Person.PersonalImg).Include(r => r.Person.Department).Include(r => r.Person.Zone).Include(r => r.RequestStatus).Include(r => r.RequestType).Include(r => r.PortalUser).FirstOrDefaultAsync();
        var dbContext = await _context.Request.Where(r => r.Id == id && r.AppointmentId == r.Appointment.Id && r.PersonId == r.Person.Id && r.RequestStatusId == r.RequestStatus.Id && r.RequestTypeId == r.RequestType.Id && r.PersonId == r.Person.Id)
        .Select(r => new
        {
            r.Id,
            r.AppointmentId,
            r.Appointment.PortalUserId,
            r.RequestStatusId,
            r.PersonId,
            r.Appointment.RiskLevelId,
            r.RequestStatus.Status,
            r.RequestStatus.BadgeColor,
            r.RequestType.Type,
            r.IsPersonShowUp,
            r.AppsentReason,
            r.Appointment.ApponitmentDate,
            r.Appointment.AppointmentDay,
            r.Appointment.AppointmentStartTime,
            r.Appointment.portalUser.Role.RoleArabName,
            r.Appointment.portalUser.UserFullName,
            r.Appointment.RiskLevel.Risk,
            r.Person.FullArabicName,
            r.Person.NationalId,
            r.Person.Entity.EntityName,
            r.Person.Department.DepartmentName,
            r.Person.PhoneNumber,
            r.Person.Zone.ZoneName,
            r.Person.Grade,
            r.Person.JobTitle,
            r.Person.DateOfBirth,
            r.Person.Title,
            r.Person.PersonalImg.PersonalImage,
            r.Person.PersonalImgId,
            r.Person.IsImportant,
            r.isEmergency
        }).FirstAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<object>(dbContext);
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetRequestDto>>> GetRequestByPersonId(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetRequestDto>>();
        var dbContext = await _context.Request.Where(r => r.PersonId == id).Include(r => r.Appointment).Include(r => r.Person).Include(r => r.RequestStatus).Include(r => r.PortalUser).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetRequestDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetRequestDto>>> GetRequestByPersonIdAndReqId(int id, int reqId)
    {
        var serviceResponse = new ServiceResponse<List<GetRequestDto>>();
        var dbContext = await _context.Request.Where(r => r.PersonId == id && r.Id == reqId && r.RequestStatusId == 4).Include(r => r.Appointment).Include(r => r.Person).Include(r => r.RequestStatus).Include(r => r.PortalUser).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetRequestDto>(p)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<DoctorStatisticsVm>>> GetRequestsStatistics()
    {
        var response = new ServiceResponse<List<DoctorStatisticsVm>>();

        try
        {
            // Pull requests joined to appointments, then resolve status via RequestStatus.Status
            var requestRows = await _context.Request
                .AsNoTracking()
                .Where(r => r.AppointmentId != null)
                .Select(r => new
                {
                    AppointmentId = r.AppointmentId!.Value,
                    r.RequestStatusId,
                    r.LastStatusDate,
                    r.CreatedDate
                })
                .Join(
                    _context.Appointment.AsNoTracking(),
                    r => r.AppointmentId,
                    a => a.Id,
                    (r, a) => new
                    {
                        DoctorId = a.PortalUserId, // doctor comes from Appointment.PortalUserId
                        r.AppointmentId,
                        r.RequestStatusId,
                        r.LastStatusDate,
                        r.CreatedDate
                    }
                )
                .Join(
                    _context.RequestStatus.AsNoTracking(),
                    x => x.RequestStatusId,
                    rs => rs.Id,
                    (x, rs) => new
                    {
                        x.DoctorId,
                        x.AppointmentId,
                        Status = rs.Status,
                        x.LastStatusDate,
                        x.CreatedDate
                    }
                )
                .ToListAsync();

            // If multiple Request rows exist per AppointmentId, keep the latest one
            var latestPerAppointment = requestRows
                .GroupBy(x => new { x.DoctorId, x.AppointmentId })
                .Select(g => g
                    .OrderByDescending(x => x.LastStatusDate ?? x.CreatedDate)
                    .First()
                )
                .ToList();

            // Load doctors that actually appear in the appointment/request set
            var doctorIds = latestPerAppointment.Select(x => x.DoctorId).Distinct().ToList();

            var doctors = await _context.PortalUser
                .AsNoTracking()
                .Where(d => doctorIds.Contains(d.Id))
                .Include(d => d.Role)
                .ToListAsync();

            response.Data = doctors.Select(d =>
            {
                var docItems = latestPerAppointment
                    .Where(x => x.DoctorId == d.Id)
                    .ToList();

                var ids = docItems.Select(x => (int)x.AppointmentId).ToList();

                return new DoctorStatisticsVm
                {
                    Id = d.Id,
                    DoctorName = d.UserFullName,            // PortalUser.UserFullName
                    DoctorRole = d.Role?.RoleArabName ?? "",    // PortalUser.Role.RoleName
                    Request = new RequestVm
                    {
                        Ids = ids,
                        AllRequestCount = ids.Count,
                        RequestStatus = docItems.Select(x => new RequestStatusVm
                        {
                            RequestId = (int)x.AppointmentId, // appointments.ids
                            Status = (string)x.Status         // RequestStatus.Status
                        }).ToList()
                    }
                };
            }).ToList();

            response.Success = true;
            response.Message = "Doctor requests statistics";
            return response;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
            response.Data = new List<DoctorStatisticsVm>();
            return response;
        }

    }

    public async Task<ServiceResponse<GetRequestStatusDto>> GetRequestStatusByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetRequestStatusDto>();
        var dbContext = await _context.RequestStatus.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetRequestStatusDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetRequestTypeDto>> GetRequestTypeByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetRequestTypeDto>();
        var dbContext = await _context.RequestType.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetRequestTypeDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestDto>> UpdateReqAppointmentId(UpdateReqAppointmentIdDto updateRequest)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestDto>();
        try
        {
            var requestAppointmentId = await _context.Request.FirstOrDefaultAsync(z => z.Id == updateRequest.Id);
            var OldData = await _context.Request.FirstOrDefaultAsync(e => e.Id == updateRequest.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (requestAppointmentId is null)
            {
                throw new Exception($"The Id '{updateRequest.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRequest, requestAppointmentId);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestDto>(requestAppointmentId);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestDto>> UpdateRequesIsSurveyInserted(UpdateRequestSurveyInsertedDto updateRequest)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestDto>();
        try
        {
            var requestSurveyInserted = await _context.Request.FirstOrDefaultAsync(z => z.Id == updateRequest.Id);
            var OldData = await _context.Request.FirstOrDefaultAsync(e => e.Id == updateRequest.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (requestSurveyInserted is null)
            {
                throw new Exception($"The Id '{updateRequest.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRequest, requestSurveyInserted);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestDto>(requestSurveyInserted);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestDto>> UpdateRequest(UpdateRequestDto updateRequest)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestDto>();
        try
        {
            var request = await _context.Request.FirstOrDefaultAsync(z => z.Id == updateRequest.Id);
            var OldData = await _context.Entity.FirstOrDefaultAsync(e => e.Id == updateRequest.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (request is null)
            {
                throw new Exception($"The Id '{updateRequest.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRequest, request);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestDto>(request);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestDto>> UpdateRequestAppsentReason(UpdateRequestAppsentReasonDto updateRequest)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestDto>();
        try
        {
            var request = await _context.Request.FirstOrDefaultAsync(z => z.Id == updateRequest.Id);
            var OldData = await _context.Request.FirstOrDefaultAsync(e => e.Id == updateRequest.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (request is null)
            {
                throw new Exception($"The Id '{updateRequest.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRequest, request);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestDto>(request);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestDto>> UpdateRequestShowUp(UpdateRequestShowupDto updateRequest)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestDto>();
        try
        {
            var requestType = await _context.Request.FirstOrDefaultAsync(z => z.Id == updateRequest.Id);
            var OldData = await _context.Request.FirstOrDefaultAsync(e => e.Id == updateRequest.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (requestType is null)
            {
                throw new Exception($"The Id '{updateRequest.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRequest, requestType);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestDto>(requestType);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestStatusDto>> UpdateRequestStatus(UpdateRequestStatusDto updateRequestStatus)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestStatusDto>();
        try
        {
            var requestStatus = await _context.RequestStatus.FirstOrDefaultAsync(z => z.Id == updateRequestStatus.Id);
            var OldData = await _context.RequestStatus.FirstOrDefaultAsync(e => e.Id == updateRequestStatus.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (requestStatus is null)
            {
                throw new Exception($"The Id '{updateRequestStatus.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRequestStatus, requestStatus);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestStatusDto>(requestStatus);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestDto>> UpdateRequestStatusId(UpdateRequestStatusIdDto updateRequest)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestDto>();
        try
        {
            var requestType = await _context.Request.FirstOrDefaultAsync(z => z.Id == updateRequest.Id);
            var OldData = await _context.Request.FirstOrDefaultAsync(e => e.Id == updateRequest.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (requestType is null)
            {
                throw new Exception($"The Id '{updateRequest.Id}'Is Not Founde...");
            }
            updateRequest.ReqStatusNote = requestType.ReqStatusNote +" , "+ updateRequest.ReqStatusNote;
            _mapper.Map(updateRequest, requestType);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestDto>(requestType);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<UpdateRequestTypeDto>> UpdateRequestType(UpdateRequestTypeDto updateRequestType)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestTypeDto>();
        try
        {
            var requestType = await _context.RequestType.FirstOrDefaultAsync(z => z.Id == updateRequestType.Id);
            var OldData = await _context.RequestType.FirstOrDefaultAsync(e => e.Id == updateRequestType.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (requestType is null)
            {
                throw new Exception($"The Id '{updateRequestType.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRequestType, requestType);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<UpdateRequestTypeDto>(requestType);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
