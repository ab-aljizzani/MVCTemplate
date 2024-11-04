using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.Entity;

public class DepartmentDto
{
    [Key]
    public int Id { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    // public Models.Entity.Entity? Entity { get; set; }
    public int EntityId { get; set; }
}
