using System;

namespace ClinicApi.Models.SurveyModel;

public class SurveyAnswer
{
    public int Id { get; set; }
    public string Answer { get; set; } = string.Empty;
    public int SurveyAnswerTypeId { get; set; }
}
