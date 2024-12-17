using System;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetUserSurveyAnswerDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    // public Person? Person { get; set; }
    public int PortalUserId { get; set; }
    // public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public int RequestId { get; set; }
    public int SurveyQuestionId { get; set; }
    public SurveyQuestion? SurveyQuestion { get; set; }
    public int SurveyAnswerId { get; set; }
    public SurveyAnswer? SurveyAnswer { get; set; }
    public int SurveyTypeId { get; set; }
    public string Note { get; set; } = string.Empty;
}
