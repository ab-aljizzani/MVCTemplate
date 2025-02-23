using System;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetUserSurveyScoreDto
{
    public string SurveyScore { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; } = false;
}
