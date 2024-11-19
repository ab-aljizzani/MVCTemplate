using System;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.ViewModel.Survey;

public class SurveyQuestionAnswerVm
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public int SurveyTypeId { get; set; }
    public int SurveyAnswerTypeId { get; set; }
    public SurveyAnswer? SurveyAnswer { get; set; }
}
