using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestAppsentReasonDto
{
    public int Id { get; set; }
    public string AppsentReason { get; set; } = string.Empty;
}
