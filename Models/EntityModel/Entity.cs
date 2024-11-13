using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.Entity;

public class Entity
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال الوحدة")]
    [Display(Name = "الوحدة")]
    public string EntityName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إدخال النوع")]
    [Display(Name = "النوع")]
    public string EntityType { get; set; } = string.Empty;
}
