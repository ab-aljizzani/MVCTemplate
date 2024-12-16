using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdateIsPersonShowup
{
    public int RequestId { get; set; }
    public bool IsPersonShowUp { get; set; }
    public int AppointmentStatusId { get; set; }
}
