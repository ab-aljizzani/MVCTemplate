using System;

namespace ClinicApi.Models.AppointmentModel;

public class Perscription
{
    public int Id { get; set; }
    public string PerscriptionName { get; set; } = string.Empty;
}
