using System;

namespace ClinicApi.Models.AppointmentModel;

public class AppointmentStatus
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public string BadgeColor { get; set; } = string.Empty;
}
