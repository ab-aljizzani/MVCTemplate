using System;

namespace ClinicApi.Dtos.RiskLevelDto.Update;

public class UpdateRiskLevelDto
{
    public int Id { get; set; }
    public string Risk { get; set; } = string.Empty;
}
