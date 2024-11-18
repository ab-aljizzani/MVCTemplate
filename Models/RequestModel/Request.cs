using System;

namespace ClinicApi.Models.RequestModel;

public class Request
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    public int RequstStatusId { get; set; }
    public int SurveyId { get; set; }
}
