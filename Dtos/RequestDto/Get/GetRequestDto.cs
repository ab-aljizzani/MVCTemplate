using System;
using ClinicApi.Models.AppointmentModel;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.RequestModel;
using ClinicApi.Models.RequestTypeModel;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetRequestDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastStatusDate { get; set; }
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public int PortalUserId { get; set; }
    // public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public int RequestStatusId { get; set; }
    public RequestStatus? RequestStatus { get; set; }
    public int RequestTypeId { get; set; }
    public RequestType? RequestType { get; set; }
    public int SurveyTypeId { get; set; }
    public SurveyType? SurveyType { get; set; }
    public int? AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }
    public string AppsentReason { get; set; } = string.Empty;
    public bool IsSurveyInserted { get; set; }


    public string UserFullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }
    public string Status { get; set; } = string.Empty;
    public bool IsFromShamel { get; set; } = false;

}
