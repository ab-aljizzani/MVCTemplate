using AutoMapper;
using MVCTemplate.Dtos.CountriesDto.Get;
using MVCTemplate.Dtos.PortalUserDto;
using MVCTemplate.Dtos.PortalUserModelDto.Insert;
using MVCTemplate.Dtos.PortalUserModelDto.Update;
using MVCTemplate.Dtos.RoleDto;
using MVCTemplate.Dtos.RoleDto.Update;
using MVCTemplate.Models.CountriesModel;
using MVCTemplate.Models.PortalUser;
using MVCTemplate.Models.Role;
using System;

namespace MVCTemplate;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<UpdateRoleDto, Role>();

        CreateMap<PortalUser, PortalUserDto>();
        CreateMap<PortalUserDto, PortalUser>();
        CreateMap<UpdatePortalUserDto, PortalUser>();
        CreateMap<InsertPortalUserDto, PortalUser>();
        CreateMap<PasswordExpireUpdateDto, PortalUser>();
        CreateMap<PasswordInitialDto, PortalUser>();
        CreateMap<UpdatePortalUserPhoneDto, PortalUser>();
        CreateMap<UpdatePortalUserRoleDto, PortalUser>();
        CreateMap<InsertPortalUserNoPersonalImgDto, PortalUser>();
        CreateMap<InsertPortalUserDto, InsertPortalUserNoPersonalImgDto>();

        CreateMap<GetCountrieDto, Countries>();
        CreateMap<Countries, GetCountrieDto>();

    }
}
