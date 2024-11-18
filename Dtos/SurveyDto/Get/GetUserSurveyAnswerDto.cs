using System;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetUserSurveyAnswerDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public int SurveyQuestionId { get; set; }
    public int SurveyAnswerId { get; set; }
    public string Note { get; set; } = string.Empty;
}
