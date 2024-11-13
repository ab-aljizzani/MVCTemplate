using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.Entity;

public class AddEntityDto
{
    [Required(ErrorMessage = "الرجاء إدخال الوحدة")]
    [Display(Name = "الوحدة")]
    public string EntityName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال النوع")]
    [Display(Name = "النوع")]
    public string EntityType { get; set; } = string.Empty;
}
