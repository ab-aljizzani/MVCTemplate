using System;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateSurveyAnswerDto
{
    public int Id { get; set; }
    public string Answer { get; set; } = string.Empty;
    public int SurveyAnswerTypeId { get; set; }
}
