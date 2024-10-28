using System;

namespace ClinicApi.Dtos.ZoneModelDto.Update;

public class UpdateZoneDto
{
    public int Id { get; set; }
    public string ZoneName { get; set; } = string.Empty;
}
