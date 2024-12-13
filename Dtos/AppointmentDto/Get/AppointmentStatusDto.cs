using System;

namespace ClinicApi.Dtos.AppointmentDto.Get;

public class AppointmentStatusDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}
