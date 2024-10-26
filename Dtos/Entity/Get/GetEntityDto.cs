using System;
using System.ComponentModel.DataAnnotations;
using ClinicApi.Models.Entity;

namespace ClinicApi.Dtos.Entity;

public class GetEntityDto
{
    public int Id { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
    public List<DepartmentDto>? Departments { get; set; }
}
