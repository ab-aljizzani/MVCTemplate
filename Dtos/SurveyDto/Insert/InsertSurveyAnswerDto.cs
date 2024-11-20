using System;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyAnswerDto
{
    public int Id { get; set; }
    public string Answer { get; set; } = string.Empty;
    public int SurveyAnswerTypeId { get; set; }
    public int SurveyQuestionId { get; set; }
}
