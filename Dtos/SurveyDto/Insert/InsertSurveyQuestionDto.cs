using System;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyQuestionDto
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public int SurveyAnswerId { get; set; }
}
