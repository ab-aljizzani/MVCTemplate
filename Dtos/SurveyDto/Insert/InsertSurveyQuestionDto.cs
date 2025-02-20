using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyQuestionDto
{
    public int Id { get; set; }
    [Required]
    public string Question { get; set; } = string.Empty;
    [Required]
    public string QuestionEng { get; set; } = string.Empty;
    [Required]
    public int SurveyTypeId { get; set; }
}
