using System;

namespace ClinicApi.Dtos.AppointmentDto.Insert;

public class InsertPerscriptionDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int PortalUserId { get; set; }
    public string CreateDate { get; set; } = string.Empty;
    public string PerscriptionName { get; set; } = string.Empty;
    public string Discription { get; set; } = string.Empty;
}
