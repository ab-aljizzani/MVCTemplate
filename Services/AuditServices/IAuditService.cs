using System;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services;

public interface IAuditService
{
    Task<bool> PostAudit(string AuditDesc);
    Task<bool> PostAuditWuthNoToken(string auditDesc, string nationalId);
    Task<bool> PutAudit(string auditDesc, object obj);
    Task<bool> PutAuditWithNoToken(string auditDesc, object obj);
}
