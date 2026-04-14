using System;
using MVCTemplate.Data;
using MVCTemplate.Models.AuditsModel;
using MVCTemplate.Models.Reponse;

namespace MVCTemplate.Services.AuditServices;

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
        var nationalId = _tokenRoles.GetRoleToken("NationalId");
        if (!int.TryParse(portalUserId, out _))
        {
            audit.PortalUserId = 0;
            audit.NationalId = nationalId;
            audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
            audit.AuditDesc = auditDesc + " " + nationalId;
            audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
            audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
            audit.AuditTime = DateTime.Now;
            audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
            audit.TableName = _httpContextAccessor.HttpContext.Request.RouteValues.Last().Value.ToString();

        }
        else
        {
            audit.PortalUserId = int.Parse(portalUserId);
            audit.NationalId = nationalId;
            audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
            audit.AuditDesc = auditDesc + " " + portalUserId;
            audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
            audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
            audit.AuditTime = DateTime.Now;
            audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
            audit.TableName = _httpContextAccessor.HttpContext.Request.RouteValues.Last().Value.ToString();
        }
        _context.Audits.Add(audit);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> PostAuditWuthNoToken(string auditDesc, string nationalId)
    {
        var audit = new Audits();
        audit.PortalUserId = 0;
        audit.NationalId = nationalId;
        audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
        audit.AuditDesc = auditDesc;
        audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
        audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
        audit.AuditTime = DateTime.Now;
        audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
        audit.TableName = _httpContextAccessor.HttpContext.Request.RouteValues.Last().Value.ToString();

        _context.Audits.Add(audit);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PutAudit(string auditDesc, object obj)
    {
        var audit = new Audits();
        var portalUserId = _tokenRoles.GetRoleToken("PortalUserId");
        var nationalId = _tokenRoles.GetRoleToken("NationalId");
        if (!int.TryParse(portalUserId, out _))
        {
            audit.PortalUserId = 0;
            audit.NationalId = nationalId;
            audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
            audit.AuditDesc = auditDesc + " " + nationalId;
            audit.AuditOldData = obj.ToString();
            audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
            audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
            audit.AuditTime = DateTime.Now;
            audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
            audit.TableName = _httpContextAccessor.HttpContext.Request.RouteValues.Last().Value.ToString();

        }
        else
        {
            audit.PortalUserId = int.Parse(portalUserId);
            audit.NationalId = nationalId;
            audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
            audit.AuditDesc = auditDesc + " " + portalUserId;
            audit.AuditOldData = obj.ToString();
            audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
            audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
            audit.AuditTime = DateTime.Now;
            audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
            audit.TableName = _httpContextAccessor.HttpContext.Request.RouteValues.Last().Value.ToString();
        }

        _context.Audits.Add(audit);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> PutAuditWithNoToken(string auditDesc, object obj)
    {
        var audit = new Audits();
        audit.PortalUserId = 0;
        audit.HttpRequest = _httpContextAccessor.HttpContext.Request.Method;
        audit.AuditDesc = auditDesc;
        audit.AuditOldData = obj.ToString();
        audit.EndPoint = _httpContextAccessor.HttpContext.Request.Path;
        audit.BaseUrl = _httpContextAccessor.HttpContext.Request.Host.ToString();
        audit.AuditTime = DateTime.Now;
        audit.AuditIp = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
        audit.TableName = _httpContextAccessor.HttpContext.Request.RouteValues.Last().Value.ToString();

        _context.Audits.Add(audit);
        await _context.SaveChangesAsync();
        return true;
    }
}
