using System;
using ClinicApi.Services.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ClinicApi.Data;

public class TokenRoles
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenRoles(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Dictionary<string, object> GetRoleToken()
    {

        var userClaims = _httpContextAccessor.HttpContext?.User.Claims.ToList();
        var userRoleType = userClaims.Select(u => u.Type).ToList();
        var userRoleValue = userClaims.Select(u => u.Value).ToList();
        var newTokenRole = new Dictionary<string, object>();
        for (int i = 0; i < userRoleValue.Count; i++)
        {
            newTokenRole.Add(userRoleType[i], userRoleValue[i]);
        }
        return newTokenRole;

    }
}
