using System;

namespace MVCTemplatePortal.Models;

public class IamRole
{
    public string RoleUrl { get; set; } = "https://10.2.51.22:8443/ords/iam/api/getUserRolesByAppl/";
    public string userName { get; set; } = string.Empty;
}
public class IamRoleRes
{
    public int ApplicationId { get; set; }
    public string ApplicationName { get; set; } = string.Empty;
    public List<Responsibility>? Responsibility { get; set; }
}

public class Responsibility
{
    public int ResponsibilityId { get; set; }
    public string ResponsibilityName { get; set; } = string.Empty;
    public string ResponsibilityNameEn { get; set; } = string.Empty;
    public string ResponsibilityDesc { get; set; } = string.Empty;
    public string ResponsibilityClass { get; set; } = string.Empty;
}
