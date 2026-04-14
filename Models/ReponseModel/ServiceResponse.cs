using System;

namespace MVCTemplate.Models.Reponse;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public object? OldData { get; set; }
}
