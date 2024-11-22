using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestStatusDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public int StatusOrder { get; set; }
}
