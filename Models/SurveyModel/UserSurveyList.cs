using System;

namespace ClinicApi.Models.SurveyModel;

public class UserSurveyList
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
