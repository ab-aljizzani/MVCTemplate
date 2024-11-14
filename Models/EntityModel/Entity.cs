using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Models.Entity;

public class Entity
{
    public int Id { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
}
