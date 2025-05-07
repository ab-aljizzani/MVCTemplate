using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdateAppointmentDto
{
    public int Id { get; set; }
    // public int RequestId { get; set; }
    public int SurveyTypeId { get; set; }
    public int PortalUserId { get; set; }
    // public int AppointmentStatusId { get; set; }
    public int PerscriptionId { get; set; }
    public string ApponitmentDate { get; set; } = string.Empty;
    public string AppointmentDay { get; set; } = string.Empty;
    public string AppointmentStartTime { get; set; } = string.Empty;
    public string AppointmentEndTime { get; set; } = string.Empty;
    // public string AppointmentReview { get; set; } = string.Empty;
    // public string AppointmentDoctorReview { get; set; } = string.Empty;
    // public bool IsSurveyInserted { get; set; }
    public bool IsPersonShowUp { get; set; }
}
