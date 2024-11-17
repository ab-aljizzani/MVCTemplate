using System;
using ClinicApi.Dtos.Entity;
using ClinicApi.Dtos.Entity.Get;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.Entity;

public interface IEntityService
{
    Task<ServiceResponse<List<GetEntityDto>>> GetAllEntitys();
    Task<ServiceResponse<GetEntityDto>> GetEntityByID(int id);
    Task<ServiceResponse<List<GetEntityDto>>> AddNewEntity(AddEntityDto newEntity);
    Task<ServiceResponse<GetEntityDto>> UpdateEntity(UpdateEntityDto updateEnityt);
    Task<ServiceResponse<GetEntityDto>> DeleteEntity(int id);


    Task<ServiceResponse<List<DepartmentDto>>> GetAlldepartments();
    Task<ServiceResponse<DepartmentDto>> GetDepartmentByID(int id);
    Task<ServiceResponse<List<DepartmentDto>>> GetDepartmentByEntityID(int id);
    Task<ServiceResponse<List<DepartmentDto>>> GetDeptEntity();
    Task<string> GetDepartmentCountByEntityID(int id);
    Task<ServiceResponse<List<GetEntityDto>>> AddNewDepartment(AddDepartmentDto newDepartment);
    Task<ServiceResponse<DepartmentDto>> UpdateDepartment(UpdateDepartmentDot updateDepartment);
    Task<ServiceResponse<GetEntityDto>> DeleteDepartment(int id);
}
