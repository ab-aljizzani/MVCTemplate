using System;
using System.ComponentModel.DataAnnotations;
using ClinicApi.Data;

namespace ClinicApi.Dtos.Entity;

public class AddEntityDto
{
    [Required(ErrorMessage = "الرجاء إدخال القطاع ")]
    [Display(Name = "القطاع")]
    public string EntityName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إختيار نوع القطاع ")]
    [Display(Name = "نوع القطاع")]
    public string EntityType { get; set; } = string.Empty;

}
