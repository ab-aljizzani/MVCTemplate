using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdateAppointmentIsSurveyInsertedDto
{
    public int Id { get; set; }
    public bool IsSurveyInserted { get; set; }
    public string SurveyScore { get; set; } = string.Empty;
}
