using System;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Data;

public interface IAuthRepositery
{

    Task<ServiceResponse<int>> Register(PortalUser user, string password);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<bool> UserExists(string username);

}
