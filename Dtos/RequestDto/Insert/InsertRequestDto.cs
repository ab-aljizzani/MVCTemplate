using System;

namespace ClinicApi.Dtos.RequestDto.Insert;

public class InsertRequestDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int PortalUserId { get; set; }
    public int RequstStatusId { get; set; }
}
