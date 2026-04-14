
using MVCTemplate.Dtos.PortalUserDto;
using MVCTemplate.Dtos.PortalUserModelDto.Insert;
using MVCTemplate.Dtos.PortalUserModelDto.Update;
using MVCTemplate.Models.Reponse;

namespace MVCTemplate.Data;

public interface IAuthRepositery
{

    Task<ServiceResponse<List<PortalUserDto>>> GetAll();
    Task<ServiceResponse<List<PortalUserDto>>> GetAllByUserType(string type);
    Task<ServiceResponse<PortalUserDto>> GetUserByID(int id);
    Task<ServiceResponse<PortalUserDto>> GetUserByNationalId(string id);
    Task<ServiceResponse<int>> Register(InsertPortalUserDto user, string password);
    Task<ServiceResponse<string>> IamRegister(InsertPortalUserDto user);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<ServiceResponse<string>> IamLogin(string username);
    Task<ServiceResponse<PortalUserDto>> UpdatePortalUser(UpdatePortalUserDto updatePortalUser);
    Task<ServiceResponse<PortalUserDto>> UpdateUserRole(UpdatePortalUserRoleDto updatePortalUser);
    Task<bool> UserExists(string username);



}
