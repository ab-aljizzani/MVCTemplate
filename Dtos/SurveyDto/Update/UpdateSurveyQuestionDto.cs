using System;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateSurveyQuestionDto
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public int SurveyTypeId { get; set; }
    public int SurveyAnswerTypeId { get; set; }
}
