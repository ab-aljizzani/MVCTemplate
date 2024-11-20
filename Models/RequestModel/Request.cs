using System;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.PortalUser;

namespace ClinicApi.Models.RequestModel;

public class Request
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public int PortalUserId { get; set; }
    public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public int RequestStatusId { get; set; }
    public RequestStatus? RequestStatus { get; set; }
}
