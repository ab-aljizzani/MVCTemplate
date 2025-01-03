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
    [Required]
    public int SurveyTypeId { get; set; }
    // public int SurveyAnswerTypeId { get; set; }
    public List<SurveyAnswer>? SurveyAnswer { get; set; }

}
