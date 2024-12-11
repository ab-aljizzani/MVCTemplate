using System;

namespace ClinicApi.Dtos.DoctorAvailbleTimeDto.Update;

public class UpdateDoctorIsActive
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = false;
}
