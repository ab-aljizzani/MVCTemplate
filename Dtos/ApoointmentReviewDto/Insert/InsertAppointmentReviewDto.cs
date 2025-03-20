using System;

namespace ClinicApi.Dtos.ApoointmentReviewDto.Insert;

public class InsertAppointmentReviewDto
{
    public int RequestId { get; set; }
    public int AppointmentId { get; set; }
    public int PortalUserId { get; set; }
    public string Review { get; set; } = string.Empty;
}
