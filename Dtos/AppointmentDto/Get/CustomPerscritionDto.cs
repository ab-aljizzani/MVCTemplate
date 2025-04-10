using System;

namespace ClinicApi.Dtos.AppointmentDto.Get;

public class CustomPerscritionDto
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string CreateDate { get; set; } = string.Empty;
    public string PerscriptionName { get; set; } = string.Empty;
    public string Discription { get; set; } = string.Empty;
    public string UserFullName { get; set; } = string.Empty;
    public string RoleArabName { get; set; } = string.Empty;
}
