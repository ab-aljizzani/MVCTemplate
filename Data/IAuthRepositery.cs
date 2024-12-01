using ClinicApi.Dtos.DashboardUserDto;
using ClinicApi.Dtos.DashboardUserDto.Insert;
using ClinicApi.Dtos.DashboardUserDto.Update;
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
    Task<ServiceResponse<PortalUserDto>> PasswordExpireUpdate(PasswordExpireUpdateDto updatePortalUser);
    Task<ServiceResponse<PortalUserDto>> PasswordInitialUpdate(PasswordInitialDto updatePortalUser);
    Task<ServiceResponse<PortalUserDto>> UpdateUserPhone(UpdatePortalUserPhoneDto updatePortalUser);
    Task<bool> UserExists(string username);



    Task<ServiceResponse<List<DashboardUserDto>>> DashboardGetAll();
    Task<ServiceResponse<List<DashboardUserDto>>> DashboardGetAllByEntityId(int id);
    Task<ServiceResponse<List<DashboardUserDto>>> DashboardGetAllByUserType(string type);
    Task<ServiceResponse<DashboardUserDto>> DashboardGetUserByID(int id);
    Task<ServiceResponse<int>> DashboardRegister(InsertDashboardUserDto user, string password);
    Task<ServiceResponse<string>> DashboardLogin(string username, string password);
    Task<ServiceResponse<DashboardUserDto>> DashboardUpdateUser(UpdateDashboardUserDto updatePortalUser);
    Task<ServiceResponse<DashboardUserDto>> DashboardPasswordExpireUpdate(DashboardPasswordExpireUpdateDto updatePortalUser);
    Task<ServiceResponse<DashboardUserDto>> DashboardPasswordInitialUpdate(DashboardPasswordInitialDto updatePortalUser);
    Task<ServiceResponse<DashboardUserDto>> DashboardUpdateUserPhone(UpdateDashboardUserPhoneDto updatePortalUser);
    Task<bool> DashboardUserExists(string username);

}
