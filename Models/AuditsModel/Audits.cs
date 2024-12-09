using System;

namespace ClinicApi.Models.AuditsModel;

public class Audits
{
    public int Id { get; set; }
    public int PortalUserId { get; set; }
    public string HttpRequest { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;
    public string AuditDesc { get; set; } = string.Empty;
    public DateTime AuditTime { get; set; } = DateTime.Now;
    public string AuditIp { get; set; } = string.Empty;
}
