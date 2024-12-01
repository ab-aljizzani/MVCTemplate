using System;

namespace ClinicApi.Dtos.DashboardUserDto;

public class DashboardLoginDto
{
    public string Username { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
}
