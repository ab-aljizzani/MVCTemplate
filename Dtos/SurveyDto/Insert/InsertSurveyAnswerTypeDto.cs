using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyAnswerTypeDto
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; } = string.Empty;
}
