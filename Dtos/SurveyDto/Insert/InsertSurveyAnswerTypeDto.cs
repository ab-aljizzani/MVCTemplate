using System;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyAnswerTypeDto
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
}
