using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicApi.Dtos.Entity;

public class AddEntityDto
{
    public string EntityName { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
}
