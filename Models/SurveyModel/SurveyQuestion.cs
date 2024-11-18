using System;

namespace ClinicApi.Models.SurveyModel;

public class SurveyQuestion
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public int SurveyAnswerId { get; set; }
}
