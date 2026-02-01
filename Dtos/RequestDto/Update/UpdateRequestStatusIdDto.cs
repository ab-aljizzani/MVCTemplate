using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestStatusIdDto
{
    public int Id { get; set; }
    public int RequestStatusId { get; set; }
    public string? ReqStatusNote { get; set; }

}
