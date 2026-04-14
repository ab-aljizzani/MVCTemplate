using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
namespace MVCTemplate.Data;

public class TokenRoles
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenRoles(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetRoleToken(string role)
    {


        var userClaims = _httpContextAccessor.HttpContext?.User.Claims.ToList();
        var userRoleType = userClaims.Select(u => u.Type).ToList();
        var userRoleValue = userClaims.Select(u => u.Value).ToList();
        var newTokenRole = new Dictionary<string, object>();

        for (int i = 0; i < userRoleValue.Count; i++)
        {
            newTokenRole.Add(userRoleType[i], userRoleValue[i]);
        }
        var setRole = newTokenRole.FirstOrDefault(t => t.Key == role);
        if (setRole.Value is null)
        {
            return "no Data";
        }
        else
            return setRole.Value.ToString();

    }
}
