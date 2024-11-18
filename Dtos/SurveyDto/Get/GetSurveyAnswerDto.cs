using System;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyAnswerDto
{
    public string Answer { get; set; } = string.Empty;
    public int SurveyAnswerTypeId { get; set; }
}
