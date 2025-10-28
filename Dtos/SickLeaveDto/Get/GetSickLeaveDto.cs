using System;

namespace ClinicApi.Dtos.SickLeaveDto.Get;

public class GetSickLeaveDto
{
    public int Id { get; set; }
    public string NumberOfDays { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public string CreateDate { get; set; } = string.Empty;
    public int AppointmentId { get; set; }
    public int PortalUserId { get; set; }
    public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public int PersonId { get; set; }
    public Models.PersonModel.Person? Person { get; set; }
    public bool IsAddedToSehaty { get; set; }
    public string SehatyAddedEmp { get; set; } = string.Empty;
    public string SehatyAddedDate { get; set; } = string.Empty;

}
