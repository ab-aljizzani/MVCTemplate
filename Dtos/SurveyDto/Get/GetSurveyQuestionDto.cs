using System;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyQuestionDto
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public int SurveyAnswerId { get; set; }
}
