using System;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyAnswerDto
{
    public int Id { get; set; }
    public string Answer { get; set; } = string.Empty;
    public string AnswerEng { get; set; } = string.Empty; public string AnswerPoint { get; set; } = string.Empty;
    // public int SurveyAnswerTypeId { get; set; }
    public SurveyQuestion? SurveyQuestion { get; set; }
}
