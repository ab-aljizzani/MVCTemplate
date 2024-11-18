using System;

namespace ClinicApi.Dtos.SurveyDto.Update;

public class UpdateSurveyTypeDto
{

    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
}
