using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdatePerscriptionDto
{
    public int Id { get; set; }
    public string PerscriptionName { get; set; } = string.Empty;
}
