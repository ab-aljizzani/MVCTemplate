using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using ClinicApi.Data;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.Entity.Get;
using ClinicApi.Models.Entity;
using ClinicApi.Models.Reponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;

namespace ClinicApi.Services.Entity;

public class EntityService : IEntityService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly MagicString _magicString;

    public EntityService(MagicString magicString, IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _magicString = magicString;
        _mapper = mapper;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<ServiceResponse<DepartmentDto>> AddNewDepartment(AddDepartmentDto newDepartment)
    {
        var serviceResponse = new ServiceResponse<DepartmentDto>();
        try
        {
            var entity = await _context.Entity.FirstOrDefaultAsync(d => d.Id == newDepartment.EntityId);
            if (entity is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Entity Not Found...";
                return serviceResponse;
            }
            if (string.IsNullOrEmpty(newDepartment.DepartmentName))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Department Name Cannot Be Null Or Empty...";
                return serviceResponse;
            }
            if (await _context.Department.AnyAsync(d => d.DepartmentName.ToLower() == newDepartment.DepartmentName.ToLower() && d.EntityId == newDepartment.EntityId))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Department Name Already Exists For This Entity...";
                return serviceResponse;
            }
            var department = _mapper.Map<Department>(newDepartment);
            _context.Department.Add(department);
            await _context.SaveChangesAsync();
            serviceResponse.Message = _magicString.InsertSuccess;
            serviceResponse.Data = _mapper.Map<DepartmentDto>(department);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<int>> AddNewEntity(AddEntityDto newEntity)
    {
        var serviceResponse = new ServiceResponse<int>();

        var entity = _mapper.Map<Models.Entity.Entity>(newEntity);
        _context.Entity.Add(entity);
        _context.SaveChanges();
        serviceResponse.Data = entity.Id;
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


    [AllowAnonymous]
    public async Task<ServiceResponse<List<DepartmentDto>>> GetAlldepartments()
    {
        var serviceResponse = new ServiceResponse<List<DepartmentDto>>();
        var dbContext = await _context.Department.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<DepartmentDto>(e)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<DepartmentDto>>> GetDeptEntity()
    {
        var serviceResponse = new ServiceResponse<List<DepartmentDto>>();
        var dbContext = await _context.Department.Include(d => d.Entity).ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<DepartmentDto>(e)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetEntityDto>>> GetAllEntitys()
    {
        var serviceResponse = new ServiceResponse<List<GetEntityDto>>();
        var dbContext = await _context.Entity.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<GetEntityDto>(e)).ToList();
        return serviceResponse;
    }



    public async Task<ServiceResponse<DepartmentDto>> GetDepartmentByID(int id)
    {
        var serviceResponse = new ServiceResponse<DepartmentDto>();
        var dbContext = await _context.Department.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<DepartmentDto>(dbContext);
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<DepartmentDto>>> GetDepartmentByEntityID(int id)
    {
        var serviceResponse = new ServiceResponse<List<DepartmentDto>>();
        var dbContext = await _context.Department.Where(w => w.EntityId == id).Include(d => d.Entity).ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<DepartmentDto>(e)).ToList();
        return serviceResponse;
    }
    public async Task<string> GetDepartmentCountByEntityID(int id)
    {
        var serviceResponse = new ServiceResponse<int>();
        var dbContext = await _context.Department.Where(e => e.EntityId == id).ToListAsync();
        var count = dbContext.Count();
        if (count.ToString() is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        return count.ToString();
    }

    public async Task<ServiceResponse<GetEntityDto>> GetEntityByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetEntityDto>();
        var dbContext = await _context.Entity.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<GetEntityDto>(dbContext);
        return serviceResponse;
    }



    public async Task<ServiceResponse<DepartmentDto>> UpdateDepartment(UpdateDepartmentDot updateDepartment)
    {
        var serviceResponse = new ServiceResponse<DepartmentDto>();
        try
        {
            var department = await _context.Department.FirstOrDefaultAsync(e => e.Id == updateDepartment.Id);
            var OldData = await _context.Department.FirstOrDefaultAsync(e => e.Id == updateDepartment.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (department is null)
            {
                throw new Exception($"The Id '{updateDepartment.Id}'Is Not Founde...");
            }
            _mapper.Map(updateDepartment, department);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<DepartmentDto>(department);
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
            var OldData = await _context.Entity.FirstOrDefaultAsync(e => e.Id == updateEnityt.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
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

    public Task<ServiceResponse<GetEntityDto>> DeleteEntity_2(int id)
    {
        throw new NotImplementedException();
    }
}
