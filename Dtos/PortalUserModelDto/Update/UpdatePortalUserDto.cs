using System;

namespace ClinicApi.Dtos.PortalUserModelDto.Update;

public class UpdatePortalUserDto
{
    public int Id { get; set; }
    public string Password { get; set; } = string.Empty;
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
}
