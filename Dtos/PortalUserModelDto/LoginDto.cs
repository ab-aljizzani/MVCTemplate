using System;

namespace ClinicApi.Dtos.PortalUserDto;

public class LoginDto
{
    public string Username { get; set; } = string.Empty;
    public string? UserPass { get; set; } = string.Empty;
}
