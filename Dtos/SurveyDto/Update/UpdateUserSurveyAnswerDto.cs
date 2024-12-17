using System;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateUserSurveyAnswerDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    public int RequestId { get; set; }
    public int SurveyQuestionId { get; set; }
    public int SurveyAnswerId { get; set; }
    public int SurveyTypeId { get; set; }
    public string Note { get; set; } = string.Empty;
}
