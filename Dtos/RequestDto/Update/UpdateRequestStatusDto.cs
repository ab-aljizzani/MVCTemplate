using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestStatus
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}
