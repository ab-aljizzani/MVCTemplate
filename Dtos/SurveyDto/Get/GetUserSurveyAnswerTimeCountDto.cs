namespace ClinicApi.Dtos.SurveyDto.Get;

public sealed class GetUserSurveyAnswerTimeCountDto
{
    public int RequestId { get; set; }
    public int Count { get; set; } // number of repeated SurveyQuestionIds
    public List<int> SurveyQuestionIds { get; set; } = new();

    public List<GetRepeatedSurveyQuestionIdDto> RepeatedQuestions { get; set; } = new();
}
