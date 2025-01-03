using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyAnswerDto
{
    public int Id { get; set; }
    [Required]
    public string Answer { get; set; } = string.Empty;
    [Required]
    public string AnswerPoint { get; set; } = string.Empty;
    [Required]
    public int SurveyQuestionId { get; set; }
}
