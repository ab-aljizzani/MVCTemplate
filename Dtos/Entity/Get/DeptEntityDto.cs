using System;
using System.ComponentModel.DataAnnotations;


namespace ClinicApi.Dtos.Entity.Get;

public class DeptEntityDto
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال الإدارة")]
    [Display(Name = "الإدارة")]
    public string DepartmentName { get; set; } = string.Empty;
    public Models.Entity.Entity? Entity { get; set; }
}
