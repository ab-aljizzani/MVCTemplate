using System;

namespace ClinicApi.Dtos.DoctorAvailbleTimeDto.Update;

public class UpdateDoctorAvailbleTimeDto
{
    public int Id { get; set; }
    public int PortalUserId { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string TimeInBetween { get; set; } = string.Empty;
}
