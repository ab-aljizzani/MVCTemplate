using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdateAppointmentDoctorReviewDto
{
    public int Id { get; set; }
    public string AppointmentDoctorReview { get; set; } = string.Empty;
    public int RiskLevelId { get; set; }
}
