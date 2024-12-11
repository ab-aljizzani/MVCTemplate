using System;

namespace ClinicApi.Models.DoctorAvailbleTimeModel;

public class DoctorAvailbleTime
{
    public int Id { get; set; }
    public int PortalUserId { get; set; }
    public string StartDate { get; set; } = string.Empty;
    public string EndDate { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string TimeInBetween { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
}
