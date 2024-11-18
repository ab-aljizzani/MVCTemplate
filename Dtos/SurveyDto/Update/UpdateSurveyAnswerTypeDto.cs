using System;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateSurveyAnswerTypeDto
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
}
