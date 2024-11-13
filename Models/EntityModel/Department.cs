using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.Entity;

public class Department
{
    public int Id { get; set; }
    [Required(ErrorMessage = "الرجاء إدخال الإدارة")]
    [Display(Name = "الإدارة")]
    public string DepartmentName { get; set; } = string.Empty;
    public int EntityId { get; set; }
}
