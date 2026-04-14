using System;
using System.Text;
using AutoMapper;
using MVCTemplate.Data;
using MVCTemplate.Dtos.RoleDto;
using MVCTemplate.Dtos.RoleDto.Update;
using MVCTemplate.Models.Reponse;
using MVCTemplate.Models.Role;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MVCTemplate.Services.RoleServices;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public RoleService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ServiceResponse<List<RoleDto>>> AddNewRole(RoleDto newRole)
    {
        var serviceResponse = new ServiceResponse<List<RoleDto>>();
        var role = _mapper.Map<Role>(newRole);
        _context.Role.Add(role);
        _context.SaveChanges();
        serviceResponse.Data = await _context.Role.Select(e => _mapper.Map<RoleDto>(e)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<RoleDto>> DeleteRole(int id)
    {
        var serviceResponse = new ServiceResponse<RoleDto>();
        try
        {
            var role = await _context.Role.FirstOrDefaultAsync(e => e.Id == id);
            if (role is null)
            {
                throw new Exception($"The Id '{id}'Is Not Founde...");
            }
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<RoleDto>(role);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<RoleDto>>> GetAllRole()
    {
        var serviceResponse = new ServiceResponse<List<RoleDto>>();
        var dbContext = await _context.Role.ToListAsync();
        serviceResponse.Data = dbContext.Select(e => _mapper.Map<RoleDto>(e)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<RoleDto>> GetRoleByEngName(string id)
    {
        var serviceResponse = new ServiceResponse<RoleDto>();
        var dbContext = await _context.Role.FirstOrDefaultAsync(e => e.RoleName.ToLower() == id.ToLower());
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<RoleDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<RoleDto>> GetRoleByID(int id)
    {
        var serviceResponse = new ServiceResponse<RoleDto>();
        var dbContext = await _context.Role.FirstOrDefaultAsync(e => e.Id == id);
        if (dbContext is null)
        {
            throw new Exception($"The Id '{id}'Is Not Founde...");
        }
        serviceResponse.Data = _mapper.Map<RoleDto>(dbContext);
        return serviceResponse;
    }

    public async Task<ServiceResponse<RoleDto>> UpdateRole(UpdateRoleDto updateRole)
    {
        var serviceResponse = new ServiceResponse<RoleDto>();
        try
        {
            var role = await _context.Role.FirstOrDefaultAsync(e => e.Id == updateRole.Id);
            var OldData = await _context.Role.FirstOrDefaultAsync(e => e.Id == updateRole.Id);
            var json = JsonConvert.SerializeObject(OldData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            serviceResponse.OldData = content.ReadAsStringAsync().Result;
            if (role is null)
            {
                throw new Exception($"The Id '{updateRole.Id}'Is Not Founde...");
            }
            _mapper.Map(updateRole, role);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<RoleDto>(role);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}
