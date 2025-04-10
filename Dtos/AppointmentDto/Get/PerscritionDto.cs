using System;
using ClinicApi.Models.AppointmentModel;

namespace ClinicApi.Dtos.AppointmentDto.Get;

public class PerscritionDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int PortalUserId { get; set; }
    public Models.PortalUser.PortalUser? PortalUser { get; set; }
    public string CreateDate { get; set; } = string.Empty;
    public string PerscriptionName { get; set; } = string.Empty;
    public string Discription { get; set; } = string.Empty;
}
