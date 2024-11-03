using System;
using AutoMapper;
using ClinicApi.Data.PersonalImagesModelDto;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.PersonalImagesModelDto;
using ClinicApi.Dtos.PersonModelDto;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.PortalUserModelDto.Update;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.RoleDto.Update;
using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Dtos.ZoneModelDto.Update;
using ClinicApi.Models.Entity;
using ClinicApi.Models.PersonalImagesModel;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Role;
using ClinicApi.Models.ZoneModel;

namespace ClinicApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Entity, GetEntityDto>();
        CreateMap<AddEntityDto, Entity>();
        CreateMap<UpdateEntityDto, Entity>();

        CreateMap<AddDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDot, Department>();

        CreateMap<Department, AddDepartmentDto>();
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentDto, Department>();

        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<UpdateRoleDto, Role>();

        CreateMap<PortalUser, PortalUserDto>();
        CreateMap<PortalUserDto, PortalUser>();
        CreateMap<UpdatePortalUserDto, PortalUser>();

        CreateMap<Zone, ZoneDto>();
        CreateMap<ZoneDto, Zone>();
        CreateMap<UpdateZoneDto, Zone>();

        CreateMap<PersonalImg, PersonalImgDto>();
        CreateMap<PersonalImgDto, PersonalImg>();
        CreateMap<UpdatePersonalImgDto, PersonalImg>();

        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();
        CreateMap<UpdatePersonDto, Person>();
    }
}
