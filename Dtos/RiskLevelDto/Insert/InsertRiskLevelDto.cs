using System;

namespace ClinicApi.Dtos.RiskLevelDto.Insert;

public class InsertRiskLevelDto
{
    public int Id { get; set; }
    public string Risk { get; set; } = string.Empty;
}
