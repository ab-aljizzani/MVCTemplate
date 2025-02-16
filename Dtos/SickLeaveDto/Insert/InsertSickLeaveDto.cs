using System;

namespace ClinicApi.Dtos.SickLeaveDto.Insert;

public class InsertSickLeaveDto
{
    public int Id { get; set; }
    public string NumberOfDays { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public int PortalUserId { get; set; }
}
