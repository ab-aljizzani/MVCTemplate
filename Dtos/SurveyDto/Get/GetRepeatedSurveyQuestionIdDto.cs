namespace ClinicApi.Dtos.SurveyDto.Get;

public sealed class GetRepeatedSurveyQuestionIdDto
{
    public int SurveyQuestionId { get; set; }
    public int RepeatCount { get; set; }
}