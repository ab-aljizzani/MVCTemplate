using System;

namespace ClinicApi.Dtos.RiskLevelDto.Get;

public class GetRiskLevelDto
{
    public int Id { get; set; }
    public string Risk { get; set; } = string.Empty;
}
