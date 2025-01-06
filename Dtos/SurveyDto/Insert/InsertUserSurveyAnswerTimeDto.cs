using System;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertUserSurveyAnswerTimeDto
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int AppointmentId { get; set; }
    public int SurveyTypeId { get; set; }
    public int SurveyQuestionId { get; set; }
    public int SurveyAnswerId { get; set; }
    public string AnswerTime { get; set; } = string.Empty;
    // public string AnswerTimeCount { get; set; } = string.Empty;
}
