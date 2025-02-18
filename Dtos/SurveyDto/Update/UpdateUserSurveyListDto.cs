using System;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateUserSurveyListDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int RequestId { get; set; }
    public int SurveyTypeId { get; set; }
    public string SurveyScore { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; } = false;
}
