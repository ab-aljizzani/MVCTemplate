using System;
using ClinicApi.Models.AppointmentModel;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.RequestModel;
using ClinicApi.Models.RequestTypeModel;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetRequestDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastStatusDate { get; set; }
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public int PortalUserId { get; set; }
    public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public int RequestStatusId { get; set; }
    public RequestStatus? RequestStatus { get; set; }
    public int RequestTypeId { get; set; }
    public RequestType? RequestType { get; set; }
    public int SurveyTypeId { get; set; }
    public int AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }
    public string AppsentReason { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; }

}
