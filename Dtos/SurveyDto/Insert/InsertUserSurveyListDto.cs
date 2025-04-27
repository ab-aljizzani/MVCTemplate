using System;

namespace ClinicApi.Dtos.SurveyDto.Insert;

public class InsertUserSurveyListDto
{
    public int AppointmentId { get; set; }
    public int RequestId { get; set; }
    public int SurveyTypeId { get; set; }
    public string SurveyScore { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; } = false;
    public bool IsPledgeApproved { get; set; } = false;
}
