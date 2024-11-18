using System;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyTypeDto
{

    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
}
