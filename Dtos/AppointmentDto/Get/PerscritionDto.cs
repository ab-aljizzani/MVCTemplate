using System;

namespace ClinicApi.Dtos.AppointmentDto.Get;

public class PerscritionDto
{
    public int Id { get; set; }
    public string PerscriptionName { get; set; } = string.Empty;
}
