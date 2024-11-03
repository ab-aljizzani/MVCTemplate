using System;
using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.PortalUserModelDto.Update;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Data;

public interface IAuthRepositery
{

    Task<ServiceResponse<int>> Register(PortalUser user, string password);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<ServiceResponse<PortalUserDto>> GetUserByID(int id);
    Task<ServiceResponse<PortalUserDto>> UpdatePortalUser(UpdatePortalUserDto updatePortalUser);
    Task<bool> UserExists(string username);

}
