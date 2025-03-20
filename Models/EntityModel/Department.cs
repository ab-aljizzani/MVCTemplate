using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.Entity;

public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public int EntityId { get; set; }
    // public int EntityId_2 { get; set; }
    public Entity? Entity { get; set; }
}
