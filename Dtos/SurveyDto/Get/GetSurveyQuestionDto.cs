using System;
using System.ComponentModel.DataAnnotations;
using ClinicApi.Models.SurveyModel;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyQuestionDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال السؤال ")]
    [Display(Name = "السؤال")]
    public string Question { get; set; } = string.Empty;
    [Required(ErrorMessage = "Qustion Is Required")]
    [Display(Name = "Question")]
    public string QuestionEng { get; set; } = string.Empty;
    [Required(ErrorMessage = "QuestionOrderNumber Is Required")]
    [Display(Name = "QuestionOrderNumber")]
    public string QuestionOrderNumber { get; set; } = string.Empty;
    [Required]
    public int SurveyTypeId { get; set; }
    // public int SurveyAnswerTypeId { get; set; }
    public List<SurveyAnswer>? SurveyAnswer { get; set; }

}
