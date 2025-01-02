using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdatePerscriptionDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string PerscriptionName { get; set; } = string.Empty;
    public string Discription { get; set; } = string.Empty;
}
