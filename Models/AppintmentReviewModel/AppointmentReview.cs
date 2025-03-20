using System;

namespace ClinicApi.Models.AppintmentReviewModel;

public class AppointmentReview
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int RequestId { get; set; }
    public int PortalUserId { get; set; }
    public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public string Review { get; set; } = string.Empty;
}
