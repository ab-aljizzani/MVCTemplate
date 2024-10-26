using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.Entity;

public class DepartmentDto
{
    public string DepartmentName { get; set; } = string.Empty;
    public int EntityId { get; set; }
}
