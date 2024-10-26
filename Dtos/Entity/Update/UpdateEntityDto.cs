using System;

namespace ClinicApi.Dtos.Entity;

public class UpdateEntityDto
{
    public int Id { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
}
