using System;

namespace ClinicApi.Models.RequestModel;

public class RequestStatus
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public int StatusOrder { get; set; }
}
