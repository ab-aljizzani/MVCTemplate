using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.SurveyModel;

public class SurveyType
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال اسم النموذج ")]
    public string Type { get; set; } = string.Empty;
}
