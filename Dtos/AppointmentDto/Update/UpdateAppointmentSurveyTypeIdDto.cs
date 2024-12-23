using System;

namespace ClinicApi.Dtos.AppointmentDto.Update;

public class UpdateAppointmentSurveyTypeIdDto
{
    public int RequestId { get; set; }
    public int SurveyTypeId { get; set; }
    public bool IsSurveyInserted { get; set; }
}
