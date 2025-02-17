using System;

namespace ClinicApi.Models.SickLeaveModel;

public class SickLeave
{
    public int Id { get; set; }
    public string NumberOfDays { get; set; } = string.Empty;
    public string StartDate { get; set; } = string.Empty;
    public int AppointmentId { get; set; }
    public int PortalUserId { get; set; }

}
