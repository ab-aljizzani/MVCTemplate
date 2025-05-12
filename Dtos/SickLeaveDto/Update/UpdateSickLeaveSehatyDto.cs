using System;

namespace ClinicApi.Dtos.SickLeaveDto.Update;

public class UpdateSickLeaveSehatyDto
{
    public int Id { get; set; }
    public bool IsAddedToSehaty { get; set; }
    public string SehatyAddedEmp { get; set; } = string.Empty;
    public string SehatyAddedDate { get; set; } = DateTime.Now.ToString();
}
