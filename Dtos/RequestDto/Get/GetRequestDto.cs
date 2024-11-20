using System;
using ClinicApi.Models.PersonModel;
using ClinicApi.Models.RequestModel;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetRequestDto
{
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public int PortalUserId { get; set; }
    public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public int RequestStatusId { get; set; }
    public RequestStatus? RequestStatus { get; set; }
}
