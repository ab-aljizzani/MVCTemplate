using System;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetUserSurveyAnswerTimeDto
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int AppointmentId { get; set; }
    public int SurveyTypeId { get; set; }
    public int SurveyQuestionId { get; set; }
    public Models.SurveyModel.SurveyQuestion? SurveyQuestion { get; set; }
    public int SurveyAnswerId { get; set; }
    public Models.SurveyModel.SurveyAnswer? SurveyAnswer { get; set; }
    public string AnswerTime { get; set; } = string.Empty;
    // public string AnswerTimeCount { get; set; } = string.Empty;
}
