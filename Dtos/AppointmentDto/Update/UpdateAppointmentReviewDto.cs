using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdateAppointmentReviewDto
{
    public int Id { get; set; }
    public string AppointmentReview { get; set; } = string.Empty;
    public int RiskLevelId { get; set; }
}
