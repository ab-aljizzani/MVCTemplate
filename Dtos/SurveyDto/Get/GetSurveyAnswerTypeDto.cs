using System;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyAnswerTypeDto
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
}
