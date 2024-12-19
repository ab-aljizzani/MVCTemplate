using System;

namespace ClinicApi.Dtos.RequestDto.Get;

public class GetRequestTypeDto
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string BadgeColor { get; set; } = string.Empty;
}
