using System;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetUserSurveyListTypesDto
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; } = false;
}
