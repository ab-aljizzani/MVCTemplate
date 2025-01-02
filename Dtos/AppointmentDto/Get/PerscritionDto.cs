using System;
using ClinicApi.Models.AppointmentModel;

namespace ClinicApi.Dtos.AppointmentDto.Get;

public class PerscritionDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string PerscriptionName { get; set; } = string.Empty;
    public string Discription { get; set; } = string.Empty;
}
