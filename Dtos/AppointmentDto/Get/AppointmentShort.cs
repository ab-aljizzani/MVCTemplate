using System;

namespace ClinicApi.Dtos.AppointmentDto.Get;

public class AppointmentShort
{
    public string ApponitmentDate { get; set; } = string.Empty;
    public string AppointmentDay { get; set; } = string.Empty;
    public string AppointmentStartTime { get; set; } = string.Empty;
}
