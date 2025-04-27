using System;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetUserSurveyListDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int RequestId { get; set; }
    public int SurveyTypeId { get; set; }
    public SurveyType? SurveyType { get; set; }
    public string SurveyScore { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; } = false;
    public bool IsPledgeApproved { get; set; } = false;
}
