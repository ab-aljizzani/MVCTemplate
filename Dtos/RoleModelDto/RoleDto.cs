using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.RoleDto;

public class RoleDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إختيار الصلاحية ")]
    [Display(Name = "الصلاحية")]
    public string RoleName { get; set; } = string.Empty;

    [Required(ErrorMessage = "الرجاء إختيار الصلاحية ")]
    [Display(Name = "الصلاحية")]
    public string RoleArabName { get; set; } = string.Empty;
    public string Roletype { get; set; } = string.Empty;
}
