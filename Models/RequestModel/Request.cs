using System;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.RequestTypeModel;

namespace ClinicApi.Models.RequestModel;

public class Request
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
    public string AppsentReason { get; set; } = string.Empty;

}
