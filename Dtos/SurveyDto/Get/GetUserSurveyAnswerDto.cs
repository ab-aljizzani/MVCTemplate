using System;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetUserSurveyAnswerDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public int SurveyQuestionId { get; set; }
    public SurveyQuestion? SurveyQuestion { get; set; }
    public int SurveyAnswerId { get; set; }
    public SurveyAnswer? SurveyAnswer { get; set; }
    public string Note { get; set; } = string.Empty;
}
