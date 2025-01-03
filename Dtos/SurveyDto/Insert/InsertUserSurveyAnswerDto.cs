using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertUserSurveyAnswerDto
{
    public int Id { get; set; }
    [Required]
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    [Required]
    public int RequestId { get; set; }
    [Required]
    public int SurveyQuestionId { get; set; }
    [Required]
    public int SurveyAnswerId { get; set; }
    [Required]
    public int SurveyTypeId { get; set; }
    public string Note { get; set; } = string.Empty;
}
