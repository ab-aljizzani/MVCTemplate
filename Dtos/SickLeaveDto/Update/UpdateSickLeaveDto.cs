using System;

namespace ClinicApi.Dtos.SickLeaveDto.Update;

public class UpdateSickLeaveDto
{
    public int Id { get; set; }
    public string NumberOfDays { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public int PortalUserId { get; set; }
}
