using System;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services;

public interface IAuditService
{
    Task<bool> PostAudit(string AuditDesc);
}
