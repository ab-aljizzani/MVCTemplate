using System;
using ClinicApi.Dtos.RequestDto.Insert;
using ClinicApi.Dtos.RoleDto;
using ClinicApi.Dtos.SurveyDto.Insert;
using ClinicApi.Dtos.ZoneModelDto;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.Seed;

public interface ISeedService
{
    Task<ServiceResponse<string>> SeedAll();
    Task<ServiceResponse<string>> SeedEntityDept();
    Task<ServiceResponse<string>> DeleteAll();
    Task<ServiceResponse<string>> BackupAndDeleteDatabase(string backupFileName = null);
    Task<ServiceResponse<string>> BackupDatabaseOnly(string backupFileName = null);
}
