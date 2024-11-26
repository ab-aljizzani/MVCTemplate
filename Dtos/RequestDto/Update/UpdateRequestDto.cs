using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestDto
{
    public int Id { get; set; }
    public DateTime LastStatusDate { get; set; }
    public int RequestStatusId { get; set; }
}
