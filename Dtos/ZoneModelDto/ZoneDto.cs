using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.ZoneModelDto;

public class ZoneDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إختيار منطقة القرب ")]
    [Display(Name = "منطقة القرب")]
    public string ZoneName { get; set; } = string.Empty;
}
