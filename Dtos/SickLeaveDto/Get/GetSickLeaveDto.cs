using System;

namespace ClinicApi.Dtos.SickLeaveDto.Get;

public class GetSickLeaveDto
{
    public int Id { get; set; }
    public string NumberOfDays { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;

}
