using ClinicApi.Dtos.PortalUserDto;
using ClinicApi.Dtos.PortalUserModelDto.Insert;
using ClinicApi.Dtos.PortalUserModelDto.Update;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Data;

public interface IAuthRepositery
{

    Task<ServiceResponse<List<PortalUserDto>>> GetAll();
    Task<ServiceResponse<List<PortalUserDto>>> GetAllByEntityId(int id);
    Task<ServiceResponse<List<PortalUserDto>>> GetAllByUserType(string type);
    Task<ServiceResponse<PortalUserDto>> GetUserByID(int id);
    Task<ServiceResponse<int>> Register(InsertPortalUserDto user, string password);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<ServiceResponse<PortalUserDto>> UpdatePortalUser(UpdatePortalUserDto updatePortalUser);
    Task<bool> UserExists(string username);

}
