using System;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyQuestionDto
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public int SurveyTypeId { get; set; }
    public int SurveyAnswerTypeId { get; set; }
    // public List<SurveyAnswer>? SurveyAnswer { get; set; }

}
