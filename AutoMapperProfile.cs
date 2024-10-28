using System;
using AutoMapper;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.RoleDto.Update;
using ClinicApi.Models.Entity;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Role;

namespace ClinicApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Entity, GetEntityDto>();
        CreateMap<AddEntityDto, Entity>();
        CreateMap<UpdateEntityDto, Entity>();
        CreateMap<AddDepartmentDto, Department>();
        CreateMap<AddDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDot, Department>();
        // CreateMap<AddEntityDto, Entity>();
        CreateMap<Department, AddDepartmentDto>();
        CreateMap<Department, DepartmentDto>();

        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<UpdateRoleDto, Role>();

        CreateMap<PortalUser, PortalUserDto>();
        CreateMap<PortalUserDto, PortalUser>();
        // CreateMap<EntityType, AddEntityTypeDto>();
        // CreateMap<AddEntityTypeDto, EntityType>();

    }
}
