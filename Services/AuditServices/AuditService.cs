using System;
using ClinicApi.Data;
using ClinicApi.Models.AuditsModel;
using ClinicApi.Models.Reponse;

namespace ClinicApi.Services.AuditServices;

public class AuditService : IAuditService
{
    private readonly TokenRoles _tokenRoles;
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditService(TokenRoles tokenRoles, DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenRoles = tokenRoles;
        _context = context;
    }
    public async Task<bool> PostAudit(string auditDesc)
    {
        var audit = new Audits();
        var portalUserId = _tokenRoles.GetRoleToken("PortalUserId");
        audit.PortalUserId = int.Parse(portalUserId);
        audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
        audit.AuditDesc = auditDesc + " " + portalUserId;
        audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
        audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
        audit.AuditTime = DateTime.Now;
        audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();

        _context.Audits.Add(audit);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> PostAuditWuthNoToken(string auditDesc)
    {
        var audit = new Audits();
        audit.PortalUserId = 0;
        audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
        audit.AuditDesc = auditDesc;
        audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
        audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
        audit.AuditTime = DateTime.Now;
        audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();

        _context.Audits.Add(audit);
        await _context.SaveChangesAsync();
        return true;
    }
}
