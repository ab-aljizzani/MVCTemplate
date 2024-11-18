using System;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetRequestDto
{
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    public int RequstStatusId { get; set; }
}
