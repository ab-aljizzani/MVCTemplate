using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.AppointmentModel;

public class Appointment
{
    [Key]
    [Required]
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int SurveyTypeId { get; set; }
    public int PortalUserId { get; set; }
    public Models.PortalUser.PortalUser? portalUser { get; set; }
    public int AppointmentStatusId { get; set; }
    public int PerscriptionId { get; set; }
    public string ApponitmentDate { get; set; } = string.Empty;
    public string AppointmentDay { get; set; } = string.Empty;
    public string AppointmentStartTime { get; set; } = string.Empty;
    public string AppointmentEndTime { get; set; } = string.Empty;
    public string AppointmentReview { get; set; } = string.Empty;
    public string ApsentReason { get; set; } = string.Empty;
    public bool IsPersonShowUp { get; set; } = false;

}
