using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.Entity;

public class Entity
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال القطاع ")]
    [Display(Name = "القطاع")]
    public string EntityName { get; set; } = string.Empty;
    [Required(ErrorMessage = "الرجاء إختيار نوع القطاع ")]
    [Display(Name = "نوع القطاع")]
    public string EntityType { get; set; } = string.Empty;
}
