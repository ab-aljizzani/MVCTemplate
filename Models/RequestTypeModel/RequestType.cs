using System;

namespace ClinicApi.Models.RequestTypeModel;

public class RequestType
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string BadgeColor { get; set; } = string.Empty;
}
