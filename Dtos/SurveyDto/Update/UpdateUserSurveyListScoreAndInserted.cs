using System;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateUserSurveyListScoreAndInserted
{
    public int Id { get; set; }
    public string SurveyScore { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; }
}
