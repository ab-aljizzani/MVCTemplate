using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyTypeDto
{

    public int Id { get; set; }
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public string EngType { get; set; } = string.Empty;
}
