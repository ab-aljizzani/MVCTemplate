using System;
using MVCTemplate.Models.Reponse;

namespace MVCTemplate.Services.Seed;

public interface ISeedService
{
    Task<ServiceResponse<string>> SeedAll();
    Task<ServiceResponse<string>> DeleteAll();
    Task<ServiceResponse<string>> BackupAndDeleteDatabase(string backupFileName = null);
    Task<ServiceResponse<string>> BackupDatabaseOnly(string backupFileName = null);
}
