using System;

namespace ClinicApi.Dtos.RequestDto.Insert;

public class InsertRequestDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastStatusDate { get; set; }
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    public int RequestStatusId { get; set; }
    public int SurveyTypeId { get; set; }
    public int RequestTypeId { get; set; }
    // public int AppointmentId { get; set; }
    public bool IsSurveyInserted { get; set; }
}
