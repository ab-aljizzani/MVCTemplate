using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.Entity;

public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    // public Entity? Entity { get; set; }
    public int EntityId { get; set; }
}
