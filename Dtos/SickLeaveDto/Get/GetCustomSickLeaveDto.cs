using System;

namespace ClinicApi.Dtos.SickLeaveDto.Get;

public class GetCustomSickLeaveDto
{
    public int Id { get; set; }
    public string NumberOfDays { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string CreateDate { get; set; } = string.Empty;
    public int AppointmentId { get; set; }
    public string UserFullName { get; set; } = string.Empty;
    public string RoleArabName { get; set; } = string.Empty;
    public bool IsAddedToSehaty { get; set; }
    public string SehatyAddedEmp { get; set; } = string.Empty;
}
