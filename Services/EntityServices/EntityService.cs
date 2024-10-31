using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.Entity;
using ClinicApi.Models.Entity;
using ClinicApi.Models.Reponse;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ClinicApi.Services.Entity;

public class EntityService : IEntityService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EntityService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<ServiceResponse<List<GetEntityDto>>> AddNewDepartment(AddDepartmentDto newDepartment)
    {
        var serviceResponse = new ServiceResponse<List<GetEntityDto>>();
        try
        {
            var entity = await _context.Entity.FirstOrDefaultAsync(d => d.Id == newDepartment.EntityId);
            if (entity is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Entity Not Found...";
                return serviceResponse;
            }
            var department = _mapper.Map<Department>(newDepartment);
            _context.Department.Add(department);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetEntityDto>>> AddNewEntity(AddEntityDto newEntity)
    {
        var serviceResponse = new ServiceResponse<List<GetEntityDto>>();

        var entity = _mapper.Map<Models.Entity.Entity>(newEntity);
        _context.Entity.Add(entity);
        _context.SaveChanges();
        serviceResponse.Data = await _context.Entity.Select(e => _mapper.Map<GetEntityDto>(e)).ToListAsync();
        return serviceResponse;

    }

    public async Task<ServiceResponse<GetEntityDto>> DeleteDepartment(int id)
    {
        var serviceResponse = new ServiceResponse<GetEntityDto>();
        try
        {
            var department = await _context.Department.FirstOrDefaultAsync(e => e.Id == id);
            if (department is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetEntityDto>(department);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetEntityDto>> DeleteEntity(int id)
    {
        var serviceResponse = new ServiceResponse<GetEntityDto>();
        try
        {
            var entity = await _context.Entity.FirstOrDefaultAsync(e => e.Id == id);
            if (entity is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Entity.Remove(entity);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetEntityDto>(entity);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }



    public async Task<ServiceResponse<List<DepartmentDto>>> GetAlldepartments()
    {
        var serviceResponse = new ServiceResponse<List<DepartmentDto>>();
        var dbContext = await _context.Department.Include(e => e.Entity).ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<DepartmentDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetEntityDto>>> GetAllEntitys()
    {
        var serviceResponse = new ServiceResponse<List<GetEntityDto>>();
        var dbContext = await _context.Entity.Include(e => e.Departments).ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<GetEntityDto>(e)).ToList();
        return serviceResponse;
    }



    public async Task<ServiceResponse<DepartmentDto>> GetDepartmentByID(int id)
    {
        var serviceResponse = new ServiceResponse<DepartmentDto>();
        var dbContext = await _context.Department.Include(e => e.Entity).FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<DepartmentDto>(dbContext);
        return serviceResponse;
    }
    public async Task<string> GetDepartmentCountByEntityID(int id)
    {
        var serviceResponse = new ServiceResponse<int>();
        var dbContext = await _context.Department.Include(e => e.Entity).Where(e => e.EntityId == id).ToListAsync();
        var count = dbContext.Count();
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }

        return count.ToString();
    }

    public async Task<ServiceResponse<GetEntityDto>> GetEntityByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetEntityDto>();
        var dbContext = await _context.Entity.Include(e => e.Departments).FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetEntityDto>(dbContext);
        return serviceResponse;
    }



    public async Task<ServiceResponse<GetEntityDto>> UpdateDepartment(UpdateDepartmentDot updateDepartment)
    {
        var serviceResponse = new ServiceResponse<GetEntityDto>();
        try
        {
            var department = await _context.Entity.FirstOrDefaultAsync(e => e.Id == updateDepartment.Id);
            if (department is null)
            {
                throw new Exception($"The Id '{updateDepartment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateDepartment, department);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetEntityDto>(department);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetEntityDto>> UpdateEntity(UpdateEntityDto updateEnityt)
    {
        var serviceResponse = new ServiceResponse<GetEntityDto>();
        try
        {
            var entity = await _context.Entity.FirstOrDefaultAsync(e => e.Id == updateEnityt.Id);
            if (entity is null)
            {
                throw new Exception($"The Id '{updateEnityt.Id}'Is Not Founde...");
            }
            _mapper.Map(updateEnityt, entity);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetEntityDto>(entity);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

}
