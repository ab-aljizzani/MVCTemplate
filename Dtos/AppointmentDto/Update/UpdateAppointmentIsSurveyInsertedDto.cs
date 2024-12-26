using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdateAppointmentIsSurveyInsertedDto
{
    public int Id { get; set; }
    public bool IsSurveyInserted { get; set; }
}
