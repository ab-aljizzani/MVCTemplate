using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    public int RequstStatusId { get; set; }
}
