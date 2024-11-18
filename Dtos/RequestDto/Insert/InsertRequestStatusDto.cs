using System;

namespace ClinicApi.Dtos.RequestDto.Insert;

public class InsertRequestStatusDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
}
