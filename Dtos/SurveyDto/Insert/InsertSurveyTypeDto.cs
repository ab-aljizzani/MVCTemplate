using System;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertSurveyTypeDto
{

    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
}
