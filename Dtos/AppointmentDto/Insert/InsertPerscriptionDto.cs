using System;

namespace ClinicApi.Dtos.AppointmentDto.Insert;

public class InsertPerscriptionDto
{
    public int Id { get; set; }
    public string PerscriptionName { get; set; } = string.Empty;
}
