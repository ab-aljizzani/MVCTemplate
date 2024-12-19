using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestTypeDto
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string BadgeColor { get; set; } = string.Empty;
}
