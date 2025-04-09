using System;

namespace ClinicApi.Dtos.ApoointmentReviewDto.Update;

public class UpdateAppointmentReview_Dto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int RequestId { get; set; }
    public int PortalUserId { get; set; }
    public string Review { get; set; } = string.Empty;
    public string ReviewDate { get; set; } = string.Empty;
}
