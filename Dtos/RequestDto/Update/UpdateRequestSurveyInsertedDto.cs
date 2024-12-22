using System;

namespace ClinicApi.Dtos.RequestDto.Update;

public class UpdateRequestSurveyInsertedDto
{
    public int Id { get; set; }
    public bool IsSurveyInserted { get; set; }
}
