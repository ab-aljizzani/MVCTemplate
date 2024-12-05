using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.ZoneModelDto;

public class ZoneDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إختيار درجة الأهمية ")]
    [Display(Name = "درجة الأهمية")]
    public string ZoneName { get; set; } = string.Empty;
}
