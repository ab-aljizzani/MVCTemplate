using System;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyAnswerDto
{
    public int Id { get; set; }
    public string Answer { get; set; } = string.Empty;
    public string AnswerPoint { get; set; } = string.Empty;
    public int SurveyQuestionId { get; set; }
}
