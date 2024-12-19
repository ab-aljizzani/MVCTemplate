using System;

namespace ClinicApi.Dtos.AppointmentDto.Insert;

public class InsertAppointmentStatusDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public string BadgeColor { get; set; } = string.Empty;
}
