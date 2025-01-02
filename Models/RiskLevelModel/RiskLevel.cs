using System;

namespace ClinicApi.Models.RiskLevelModel;

public class RiskLevel
{
    public int Id { get; set; }
    public string Risk { get; set; } = string.Empty;
}
