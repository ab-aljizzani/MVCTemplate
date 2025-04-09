using System;

namespace ClinicApi.Dtos.ApoointmentReviewDto.Get;

public class GetCustomAppointmentReivewDto
{
    public string Review { get; set; } = string.Empty;
    public string ReviewDate { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;
}
