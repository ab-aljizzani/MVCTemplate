using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateSurveyAnswerDto
{
    public int Id { get; set; }
    [Required]
    public string Answer { get; set; } = string.Empty;
    [Required]
    public string AnswerEng { get; set; } = string.Empty;
    [Required]
    public int SurveyAnswerTypeId { get; set; }
}
