using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.SurveyDto.Get;

public class GetSurveyTypeDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال اسم النموذج ")]
    [Display(Name = "اسم النموذج")]
    public string Type { get; set; } = string.Empty;
}
