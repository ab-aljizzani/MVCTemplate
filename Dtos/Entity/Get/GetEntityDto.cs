using System;
using System.ComponentModel.DataAnnotations;
using ClinicApi.Models.Entity;

namespace ClinicApi.Dtos.Entity;

public class GetEntityDto
{
    public int Id { get; set; }
    [Display(Name = "الوحدة")]
    public string EntityName { get; set; } = string.Empty;
    [Display(Name = "النوع")]
    public string EntityType { get; set; } = string.Empty;
    // public DepartmentDto? Departments { get; set; }
}
