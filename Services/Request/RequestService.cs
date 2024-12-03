using System;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.RequestDto.Get;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RequestDto.Update;
using ClinicApi.Models.Reponse;
using Microsoft.EntityFrameworkCore;

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
        var dbContext = await _context.Request.Include(r => r.Person).Include(r => r.RequestStatus).Include(r => r.RequestType).Include(r => r.PortalUser).ToListAsync();
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

    public async Task<ServiceResponse<GetRequestDto>> GetRequestByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetRequestDto>();
        var dbContext = await _context.Request.FirstOrDefaultAsync(p => p.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetRequestDto>(dbContext);
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetRequestDto>>> GetRequestByPersonId(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetRequestDto>>();
        var dbContext = await _context.Request.Where(r => r.PersonId == id).Include(r => r.Person).Include(r => r.RequestStatus).Include(r => r.PortalUser).ToListAsync();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = dbContext.Select(p => _mapper.Map<GetRequestDto>(p)).ToList();
        return serviceResponse;
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

    public async Task<ServiceResponse<UpdateRequestDto>> UpdateRequest(UpdateRequestDto updateRequest)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestDto>();
        try
        {
            var request = await _context.Request.FirstOrDefaultAsync(z => z.Id == updateRequest.Id);
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

    public async Task<ServiceResponse<UpdateRequestStatusDto>> UpdateRequestStatus(UpdateRequestStatusDto updateRequestStatus)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestStatusDto>();
        try
        {
            var requestStatus = await _context.RequestStatus.FirstOrDefaultAsync(z => z.Id == updateRequestStatus.Id);
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

    public async Task<ServiceResponse<UpdateRequestTypeDto>> UpdateRequestType(UpdateRequestTypeDto updateRequestType)
    {
        var serviceResponse = new ServiceResponse<UpdateRequestTypeDto>();
        try
        {
            var requestType = await _context.RequestType.FirstOrDefaultAsync(z => z.Id == updateRequestType.Id);
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
