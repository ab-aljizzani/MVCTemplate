using System;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetRequestStatusDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public int StatusOrder { get; set; }
}
